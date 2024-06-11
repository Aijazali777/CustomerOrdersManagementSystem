using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtremeAspNetCoreAppDemo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreAppDemo1.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerRepository customerRepo;

        public HomeController(ICustomerRepository customerRepository)
        {
            customerRepo = customerRepository;
        }

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
