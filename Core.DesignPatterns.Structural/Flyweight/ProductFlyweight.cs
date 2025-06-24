using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Flyweight
{
    public class ProductFlyweight
    {
        public string Brand { get; }
        public string Category { get; }
        public string Warranty { get; }

        public ProductFlyweight(string brand, string category, string warranty)
        {
            Brand = brand;
            Category = category;
            Warranty = warranty;
        }

        public void Display(string name, decimal price)
        {
            Console.WriteLine($"{name} | Rs.{price} | {Brand} | {Category} | {Warranty}");
        }
    }
}
