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
    public class OrdersController : Controller
    {
        private AppDbContext _context;

        public OrdersController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Orders()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var orders = _context.Orders.Select(i => new {
                i.OrderId,
                i.CustomerId,
                i.NumberOfItems,
                i.TotalPrice,
                i.PaymentStatus
            });

            // If underlying data is a large SQL table, specify PrimaryKey and PaginateViaPrimaryKey.
            // This can make SQL execution plans more efficient.
            // For more detailed information, please refer to this discussion: https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "OrderId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(orders, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Order();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Orders.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.OrderId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Orders.FirstOrDefaultAsync(item => item.OrderId == key);
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
            var model = await _context.Orders.FirstOrDefaultAsync(item => item.OrderId == key);

            _context.Orders.Remove(model);
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

        private void PopulateModel(Order model, IDictionary values) {
            string ORDER_ID = nameof(Order.OrderId);
            string CUSTOMER_ID = nameof(Order.CustomerId);
            string NUMBER_OF_ITEMS = nameof(Order.NumberOfItems);
            string TOTAL_PRICE = nameof(Order.TotalPrice);
            string PAYMENT_STATUS = nameof(Order.PaymentStatus);

            if (values.Contains(ORDER_ID)) {
                model.OrderId = Convert.ToInt32(values[ORDER_ID]);
            }

            if (values.Contains(CUSTOMER_ID))
            {
                model.CustomerId = Convert.ToInt32(values[CUSTOMER_ID]);
            }

            if (values.Contains(NUMBER_OF_ITEMS))
            {
                model.NumberOfItems = Convert.ToInt32(values[NUMBER_OF_ITEMS]);
            }

            if (values.Contains(TOTAL_PRICE)) {
                model.TotalPrice = Convert.ToDouble(values[TOTAL_PRICE], CultureInfo.InvariantCulture);
            }

            if (values.Contains(PAYMENT_STATUS))
            {
                model.PaymentStatus = Convert.ToString(values[PAYMENT_STATUS]);
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