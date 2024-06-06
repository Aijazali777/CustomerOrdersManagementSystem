using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreAppDemo1.Models
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private AppDbContext context;

        public SQLCustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return context.Customers.FirstOrDefault(cust => cust.Id == id);
        }
    }
}
