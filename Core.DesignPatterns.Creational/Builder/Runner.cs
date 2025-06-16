using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Builder
{
    public class Runner
    {
        public static void Execute()
        {
            var builder = new OrderBuilder();
            var order = builder.AddProduct(new Product { Id = 1, Name = "Book", Price = 250 })
                               .AddProduct(new Product { Id = 2, Name = "Pen", Price = 50 })
                               .Build();

            Console.WriteLine("Order built with products:");
            foreach (var product in order.Products)
            {
                Console.WriteLine($"- {product.Name} ({product.Price} INR)");
            }
            Console.WriteLine($"Total: {order.TotalPrice} INR");
        }
    }
}
