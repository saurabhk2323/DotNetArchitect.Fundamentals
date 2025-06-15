using Core.DesignPrinciples.Contracts;
using Core.DesignPrinciples.Models;

namespace Core.DesignPrinciples.Services
{
    public class InventoryService: IInventoryService
    {
        private readonly ILogger<InventoryService> logger;
        private readonly IList<Product> _inventory;

        public InventoryService(ILogger<InventoryService> logger)
        {
            this.logger = logger;
            _inventory = GetProducts();
        }

        public void UpdateInventory(string? productId, int quantity)
        {
            var product = _inventory.Where(x => x.Id == productId).FirstOrDefault();
            if (product != null)
            {
                product.AvailableQuantity -= quantity;
            }
        }

        public bool CheckProductAvailability(string? productId, int quantity)
        {
            return string.IsNullOrWhiteSpace(productId) ? false : _inventory.Where(x => x.Id == productId).FirstOrDefault()?.AvailableQuantity >= quantity;
        }

        private IList<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = "P001",
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with adjustable DPI.",
                    AvailableQuantity = 50,
                    Price = 899.99m,
                    Category = "Electronics"
                },
                new Product
                {
                    Id = "P002",
                    Name = "Bluetooth Speaker",
                    Description = "Portable speaker with high-quality sound.",
                    AvailableQuantity = 30,
                    Price = 1999.50m,
                    Category = "Audio"
                },
                new Product
                {
                    Id = "P003",
                    Name = "Running Shoes",
                    Description = "Lightweight shoes for daily running.",
                    AvailableQuantity = 20,
                    Price = 2999.00m,
                    Category = "Footwear"
                },
                new Product
                {
                    Id = "P004",
                    Name = "Smart Watch",
                    Description = "Fitness tracker with heart rate monitor.",
                    AvailableQuantity = 15,
                    Price = 5499.99m,
                    Category = "Wearables"
                },
                new Product
                {
                    Id = "P005",
                    Name = "Backpack",
                    Description = "Water-resistant laptop backpack with USB port.",
                    AvailableQuantity = 40,
                    Price = 1499.00m,
                    Category = "Accessories"
                }
            };
        }
    }
}
