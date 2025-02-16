using ECommerce.Web.Database;
using ECommerce.Web.Migrations;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public AdminController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Products = _context.Products.ToList();
            return View(Products);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product Courses)
        {
           string webRootPath = _environment.WebRootPath;
            var file = HttpContext.Request.Form.Files;
            if (file.Count > 0)
            {
                var newFileName = Guid.NewGuid().ToString();
                var upload = Path.Combine(webRootPath, @"images/Course");
                var extension = Path.GetExtension(file[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }
                Courses.Image = @"/images/Course/" +newFileName + extension;


            }
                var products = _context.Products.Add(Courses);
                _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult getProductId(int CourseId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == CourseId);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);

            }
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(product);

        }
        [HttpPost]
        public IActionResult EditProduct(Product Course)
        {
            string webRootPath = _environment.WebRootPath;
            var file = HttpContext.Request.Form.Files;
            if (file.Count > 0)
            {
                var newFileName = Guid.NewGuid().ToString();
                var upload = Path.Combine(webRootPath, @"images/Course");
                var extension = Path.GetExtension(file[0].FileName);
                var objFromDb = _context.Products.AsNoTracking().FirstOrDefault(x=>x.Id == Course.Id);
               
                    if (objFromDb.Image != null)
                    {
                        var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.Trim('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }
                    }
          
                using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }

                Course.Image = @"/images/Course/" + newFileName + extension;


            }
            _context.Products.Update(Course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeleteCourse(int id)
        {
            var course = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(course);
        }
        [HttpPost]
        public IActionResult DeleteCourse(Product Course)
        {
            var objFromDb = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == Course.Id);
            string webRootPath = _environment.WebRootPath;
            if (objFromDb.Image != null)
            {
                var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.Trim('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);

                }
            }
            _context.Products.Remove(Course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
