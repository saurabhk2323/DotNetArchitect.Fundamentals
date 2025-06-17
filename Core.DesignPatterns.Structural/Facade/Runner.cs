using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Facade
{
    public class Runner
    {
        public static void Execute()
        {
            var orderFacade = new OrderFacade();
            var product = new Product { Id = 1, Name = "Laptop", Price = 85000 };
            orderFacade.PlaceOrder(product, "customer@email.com");
        }
    }
}
