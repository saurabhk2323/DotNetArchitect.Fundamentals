using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Composite
{
    public class Runner
    {
        public static void Execute()
        {
            var keyboard = new OrderItem("Mechanical Keyboard", 2000);
            var mouse = new OrderItem("Gaming Mouse", 1500);

            var bundle = new OrderGroup("Gaming Combo - B1G1");
            bundle.AddComponent(keyboard);
            bundle.AddComponent(mouse);

            // Apply a combo discount of 10%
            bundle.ApplyDiscount(10);

            var monitor = new OrderItem("24\" Monitor", 9000);

            // Apply a sell out 50% discount to everything
            monitor.ApplyDiscount(50);
            var fullOrder = new OrderGroup("Full Workstation Order");
            fullOrder.AddComponent(bundle);
            fullOrder.AddComponent(monitor);

            // Apply a festive 10% discount to everything
            fullOrder.ApplyDiscount(10);

            // Show total and invoice
            Console.WriteLine($"Total Order Price: Rs.{fullOrder.GetTotalPrice()}\n");
            Console.WriteLine("Invoice:\n" + fullOrder.GenerateInvoice());
        }
    }
}
