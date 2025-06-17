using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Proxy
{
    public class OrderService : IOrderService
    {
        public Order GetOrder(int orderId)
        {
            Console.WriteLine("Fetching from DB...");
            return new Order { Id = orderId }; // Imagine DB call here
        }
    }
}
