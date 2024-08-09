using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreAppDemo1.Models
{
    public class CryptoOrder
    {
        public int CryptoId { get; set; }
        public int CustomerId { get; set; }
        public string Symbol { get; set; }
        public double Quantity { get; set; }
        public string Price { get; set; }
        public Customer Customers { get; set; }
    }
}
