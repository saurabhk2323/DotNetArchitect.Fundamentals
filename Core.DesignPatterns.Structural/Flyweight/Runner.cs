using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Flyweight
{
    public class Runner
    {
        public static void Execute()
        {
            // keeps the record of items of common properties
            var factory = new FlyweightFactory();

            var appleLaptopFlyweight = factory.GetFlyweight("Apple", "Laptop", "1 Year");
            var dellLaptopFlyweight = factory.GetFlyweight("Dell", "Laptop", "2 Years");

            // order 1 & order 2 uses the samne flyweight - appleLaptopFlyweight
            var order1 = new OrderItem("MacBook Air", 120000, appleLaptopFlyweight);
            var order2 = new OrderItem("MacBook Pro", 185000, appleLaptopFlyweight);

            // order 3 uses dellLaptopFlyweight
            var order3 = new OrderItem("Dell Inspiron", 70000, dellLaptopFlyweight);

            order1.PrintDetails();
            order2.PrintDetails();
            order3.PrintDetails();
        }
    }
}
