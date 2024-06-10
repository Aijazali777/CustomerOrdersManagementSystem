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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
