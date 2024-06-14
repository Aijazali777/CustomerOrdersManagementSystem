using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtremeAspNetCoreAppDemo1.Models;

namespace DevExtremeAspNetCoreAppDemo1.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Customers()
        {
            return View();
        }

        public IActionResult CustomerOrderView()
        {
            return View();
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult ClickSignUp(Customer model)
        {
            _context.Customers.Add(model);
            _context.SaveChanges();
            bool loginMessgae = false;
            ViewBag.LoginMessage = loginMessgae;
            return View("Login");
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Login()
        {
            bool loginMessgae = false;
            ViewBag.LoginMessage = loginMessgae;
            return View();
        }

        [HttpPost]
        public IActionResult ClickLogin(Customer model)
        {
            if (ModelState.IsValid)
            {
                var cust = _context.Customers.FirstOrDefault(e => e.Name == model.Name && e.Password == model.Password);
                if (cust != null)
                {
                    return View("UserCustomerView", cust);
                }
                else
                {
                    bool loginMessgae = true;
                    ViewBag.LoginMessage = loginMessgae;
                    return View("Login");
                }      
            }
            else
            {
                return View("Login");
            }     
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult AdminLogin()
        {
            bool loginMessgae = false;
            ViewBag.LoginMessage = loginMessgae;
            return View();
        }

        [HttpPost]
        public IActionResult ClickAdminLogin(Admin model)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.Admin.FirstOrDefault(a => a.Username == model.Username && a.Password == model.Password);
                if (admin != null)
                {
                    return View("CustomerOrderView");
                }
                else
                {
                    bool loginMessgae = true;
                    ViewBag.LoginMessage = loginMessgae;
                    return View("AdminLogin");
                }
            }
            else
            {
                return View("AdminLogin");
            }
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var  customers = _context.Customers;
            return DataSourceLoader.Load(customers, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Customer();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Customers.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Customers.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.Customers.FirstOrDefaultAsync(item => item.Id == key);

            _context.Customers.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Customer model, IDictionary values)
        {
            string ID = nameof(Customer.Id);
            string NAME = nameof(Customer.Name);
            string PASSWORD = nameof(Customer.Password);
            string GENDER = nameof(Customer.Gender);
            string PHONE = nameof(Customer.Phone);
            string ADDRESS = nameof(Customer.Address);
            string CITY = nameof(Customer.City);
            string COUNTRY = nameof(Customer.Country);

            if (values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if (values.Contains(PASSWORD))
            {
                model.Password = Convert.ToString(values[PASSWORD]);
            }

            if (values.Contains(GENDER))
            {
                model.Gender = Convert.ToString(values[GENDER]);
            }

            if (values.Contains(PHONE))
            {
                model.Phone = Convert.ToDouble(values[PHONE]);
            }

            if (values.Contains(ADDRESS)) {
                model.Address = Convert.ToString(values[ADDRESS]);
            }

            if (values.Contains(CITY))
            {
                model.City = Convert.ToString(values[CITY]);
            }

            if (values.Contains(COUNTRY))
            {
                model.Country = Convert.ToString(values[COUNTRY]);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}