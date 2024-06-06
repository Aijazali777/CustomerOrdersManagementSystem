using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreAppDemo1.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int NumberOfItems { get; set; }
        public double TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public Customer Customers { get; set; }
    }
}
