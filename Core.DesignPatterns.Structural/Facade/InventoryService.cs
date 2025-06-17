using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Facade
{
    public class InventoryService
    {
        public static void Reserve(int productId) =>
            Console.WriteLine($"[Inventory] Reserved product ID {productId}");
    }
}
