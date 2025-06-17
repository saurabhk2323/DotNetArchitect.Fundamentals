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

        public decimal Price { get; }

        public OrderItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public decimal GetTotalPrice() => Price;
    }
}
