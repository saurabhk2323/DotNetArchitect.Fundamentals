using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Proxy
{
    public class Runner
    {
        public static void Execute()
        {
            IOrderService dbService = new OrderService();
            var order = dbService.GetOrder(1);
            Console.WriteLine($"Order retrieved: {order.Id}");
        }
    }
}
