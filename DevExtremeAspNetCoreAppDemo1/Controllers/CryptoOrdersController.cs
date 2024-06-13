using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevExtremeAspNetCoreAppDemo1.Models;

namespace DevExtremeAspNetCoreAppDemo1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CryptoOrdersController : Controller
    {
        private AppDbContext _context;

        public CryptoOrdersController(AppDbContext context) {
            _context = context;
        }

        public IActionResult CryptoOrders()
        {
            return View();
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions, int? customerId)
        {
            if (customerId != null)
            {
                var cryptoOrders = _context.CryptoOrders.Where(cryptoOrder => cryptoOrder.CustomerId == customerId);
                return DataSourceLoader.Load(cryptoOrders, loadOptions);
            }
            else
            {
                var allCryptoOrders = _context.CryptoOrders;
                return DataSourceLoader.Load(allCryptoOrders, loadOptions);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new CryptoOrder();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.CryptoOrders.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.CryptoId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.CryptoOrders.FirstOrDefaultAsync(item => item.CryptoId == key);
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
        public async Task Delete(int key) {
            var model = await _context.CryptoOrders.FirstOrDefaultAsync(item => item.CryptoId == key);

            _context.CryptoOrders.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CustomersLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Customers
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(CryptoOrder model, IDictionary values) {
            string CRYPTO_ID = nameof(CryptoOrder.CryptoId);
            string CUSTOMER_ID = nameof(CryptoOrder.CustomerId);
            string SYMBOL = nameof(CryptoOrder.Symbol);
            string QUANTITY = nameof(CryptoOrder.Quantity);
            string PRICE = nameof(CryptoOrder.Price);

            if(values.Contains(CRYPTO_ID)) {
                model.CryptoId = Convert.ToInt32(values[CRYPTO_ID]);
            }

            if(values.Contains(CUSTOMER_ID)) {
                model.CustomerId = Convert.ToInt32(values[CUSTOMER_ID]);
            }

            if(values.Contains(SYMBOL)) {
                model.Symbol = Convert.ToString(values[SYMBOL]);
            }

            if(values.Contains(QUANTITY)) {
                model.Quantity = Convert.ToDouble(values[QUANTITY], CultureInfo.InvariantCulture);
            }

            if(values.Contains(PRICE)) {
                model.Price = Convert.ToString(values[PRICE]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}