using DevExtremeAspNetCoreAppDemo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreAppDemo1.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
