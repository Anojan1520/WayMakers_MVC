using ECommerce.Web.Database;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
           var Products = _context.Products.ToList();
            return View(Products);
        }


    }
}
