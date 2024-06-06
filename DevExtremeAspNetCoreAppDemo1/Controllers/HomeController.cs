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

      /*  public object Get(DataSourceLoadOptions loadOptions)
        {
            var customers = customerRepo.GetAllCustomers();
            return DataSourceLoader.Load(customers, loadOptions);
            // var result = DataSourceLoader.Load(customers, loadOptions);
            //  return Json(result);
        }*/

        public IActionResult Index()
        {
           // var model = customerRepo.GetAllCustomers();
            return View();
        }
    }
}
