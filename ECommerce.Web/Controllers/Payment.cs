using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class Payment : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Process()
        {
            return View();
        }
    }
}
