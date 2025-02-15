using ECommerce.Web.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var Products = _context.Products.ToList();
            return View(Products);
        }
        [HttpPost]
        public IActionResult CreateProduct()
        {
            return View();
        }
    }
}
