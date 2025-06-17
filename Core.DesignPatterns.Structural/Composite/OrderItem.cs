using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Composite
{
    public class OrderItem : IOrderComponent
    {
        public string Name { get; }

        public decimal Price { get; private set; }

        public OrderItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public decimal GetTotalPrice() => Price;

        public void ApplyDiscount(decimal percentage)
        {
            Price -= (Price * (percentage / 100));
        }

        public string GenerateInvoice()
        {
            return $"{Name}: Rs.{Price}";
        }
    }
}
