using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Behavioral.Command
{
    public class Runner
    {
        public static void Execute()
        {

            var queue = new CommandQueueInvoker();

            // Simulate Order + Notification + Logging
            string orderId = "ORD124";
            string product = "Apple Watch Ultra";
            string customer = "saurabh@example.com";

            queue.AddCommand(new OrderCommand(orderId, product));
            queue.AddCommand(new NotifyCommand(customer, $"Your order {orderId} has been placed."));
            queue.AddCommand(new LogCommand($"Order {orderId} placed for {product} by {customer}."));

            // Later: background job calls
            queue.ProcessAll();
        }
    }
}
