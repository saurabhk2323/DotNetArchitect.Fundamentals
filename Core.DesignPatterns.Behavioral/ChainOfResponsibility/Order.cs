using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class Order
    {
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
    }
}
