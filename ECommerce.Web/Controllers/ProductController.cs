using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = new List<Product>
        {
                new Product  {
    Name = "Eco-Friendly Technology",
    Description = "Learn how to develop sustainable technologies and make an impact on the environment with innovative green solutions.",
    Price = 100
},
new Product  {
    Name = "Executive Leadership",
    Description = "A comprehensive course on leadership skills for executives, focusing on decision-making, team management, and strategic planning.",
    Price = 1250
},
new Product  {
    Name = "Urban Commuting Solutions",
    Description = "Understand the challenges of urban transportation and develop solutions for sustainable and efficient commuting options.",
    Price = 100
},
new Product  {
    Name = "Advanced Audio Engineering",
    Description = "Master the art of audio engineering, from sound design to mixing, with advanced techniques in both studio and live environments.",
    Price = 1250
}
            };
            return View(products);
        }


    }
}
