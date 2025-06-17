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
            var item1 = new OrderItem("Keyboard", 1500);
            var item2 = new OrderItem("Mouse", 700);
            var item3 = new OrderItem("Monitor", 10000);

            var peripheralsGroup = new OrderGroup("Peripherals");
            peripheralsGroup.AddComponent(item1);
            peripheralsGroup.AddComponent(item2);

            var workstationGroup = new OrderGroup("Workstation Order");
            workstationGroup.AddComponent(peripheralsGroup);
            workstationGroup.AddComponent(item3);

            Console.WriteLine($"{workstationGroup.Name} total: Rs.{workstationGroup.GetTotalPrice()}");
        }
    }
}
