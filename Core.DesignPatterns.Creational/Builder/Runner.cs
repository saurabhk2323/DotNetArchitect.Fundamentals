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
            var order = builder.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 50000 })
                               .AddProduct(new Product { Id = 2, Name = "Mouse", Price = 1500 })
                               .MarkAsGift()
                               .WithDiscount(10)
                               .WithShippingType("Express")
                               .ApplyPromoCode("SUMMER10")
                               .PayWith("Credit Card")
                               .Build();

            Console.WriteLine("Order Summary:");
            Console.WriteLine($"Is Gift: {order.IsGift}");
            Console.WriteLine($"Shipping: {order.ShippingType}");
            Console.WriteLine($"Promo Code: {order.PromoCode}");
            Console.WriteLine($"Payment Method: {order.PaymentMethod}");
            Console.WriteLine("Products:");
            foreach (var product in order.Products)
            {
                Console.WriteLine($"- {product.Name} ({product.Price} INR)");
            }
            Console.WriteLine($"Discount: {order.DiscountPercentage}%");
            Console.WriteLine($"Total: {order.TotalPrice} INR");
        }
    }
}
