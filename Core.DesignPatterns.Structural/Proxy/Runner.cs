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
            CachedOrderProxy cachedOrderProxy = new CachedOrderProxy(dbService);
            var order = cachedOrderProxy.GetOrder(1);
            Console.WriteLine($"Order retrieved: {order.Id}");
            var fetchAgain = cachedOrderProxy.GetOrder(1);
            Console.WriteLine($"Order retrieved: {order.Id}");
        }
    }
}
