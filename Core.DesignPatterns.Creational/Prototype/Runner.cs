using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Prototype
{
    public class Runner
    {
        public static void Execute()
        {
            var originalOrder = new Order
            {
                Id = 1001,
                IsGift = true,
                DiscountPercentage = 15,
                ShippingType = "Express",
                PromoCode = "LOYAL10",
                PaymentMethod = "PayPal",
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Phone", Price = 30000 },
                    new Product { Id = 2, Name = "Charger", Price = 2000 }
                }
            };

            var clonedOrder = (Order)originalOrder.Clone();
            clonedOrder.Id = 1002;
            clonedOrder.PromoCode = "REPEAT20";

            Console.WriteLine("Original Order Total: " + originalOrder.TotalPrice);
            Console.WriteLine("Cloned Order Total: " + clonedOrder.TotalPrice);
        }
    }
}
