using Core.DesignPrinciples.Common;
using Core.DesignPrinciples.Contracts;
using Core.DesignPrinciples.Models;

namespace Core.DesignPrinciples.Services
{
    /*
     OrderService is given a lot of responsibilities which are not directly interconnected
     Notification Service should be placed in a different class so as the Inventory
     */
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;

        // database is not configured for this projet, in memory role play for database
        private readonly IList<Order> _orders;

        private readonly IList<Product> _inventory;
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
            _orders = new List<Order>();
            _inventory = GetProducts();
        }

        public void CreateOrder(CreateOrderDto createOrderDto)
        {
            if (createOrderDto == null) 
            {
                return;
            }

            if (createOrderDto?.OrderedProducts?.All(x => CheckProductAvailability(x.Id, x.Quantity)) == false)
            {
                _logger.LogInformation("Order cannot be created due to unavailability of one or more products");
                return;
            }

            // create a new order
            Order order = new()
            {
                Id = Guid.NewGuid().ToString(),
                OrderedProducts = createOrderDto?.OrderedProducts,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
            };
            order.CalculateTotalAmount();
            order.CalculateTotalCount();

            // save the order in DB
            _orders.Add(order);

            // update the inventory
            order?.OrderedProducts?.ForEach(orderedProduct => UpdateInventory(orderedProduct.Id, orderedProduct.Quantity));

            _logger.LogInformation($"Order is created - {order?.Id}", LogLevel.Information);

            // send notification
            SendNotification(NotificationType.email, "Order is created");
        }

        public void UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            var order = _orders.Where(x => x.Id == updateOrderDto.Id).FirstOrDefault();
            if (order != null)
            {
                order.OrderedProducts = updateOrderDto.OrderedProducts;
                order.ModifiedAt = DateTime.UtcNow;
                order.CalculateTotalAmount();
                order.CalculateTotalCount();

                _logger.LogInformation($"Updated {order.Id}", LogLevel.Information);

                SendNotification(NotificationType.sms, $"Updated {order.Id}");
            }
            else
            {
                _logger.LogInformation($"Order not found: {updateOrderDto.Id}");
            }
        }

        public void CancelOrder(string orderId)
        {
            var order = _orders.Where(x => x.Id == orderId).FirstOrDefault();
            if (order != null)
            {
                _orders.Remove(order);
                _logger.LogInformation($"Cancelled {order.Id}", LogLevel.Information);
                SendNotification(NotificationType.email, $"Cancelled {order.Id}");
            }
            else
            {
                _logger.LogInformation($"Order not found: {orderId}");
            }
        }

        /*Observation: It's violating OCP, when a new notification type is introduced, this function needs to be re-written/updated
         Rather than serving all notification services inside a same function, the responsibilities can be offloaded with the use of base/children relation - inheritances

         */
        public void SendNotification(NotificationType type, string message)
        {
            switch (type)
            {
                case NotificationType.email:
                    /* perform operations to send the notification via email */
                    _logger.LogInformation($"Send Email Notification: {message}", LogLevel.Information);
                    break;


                case NotificationType.sms:
                    /* perform operations to send the notification via sms */
                    _logger.LogInformation($"Send SMS Notification: {message}", LogLevel.Information);
                    break;

                // let's assume tomorrow client request to add a newer notification system, edit the existing code to support the new requirement
                // this will lead to the violation of open closed principle 
                #region future requirement

                //case NotificationType.push:
                //    /* perform operations to send the notification as a push notification */
                //    _logger.LogInformation($"Send Push Notification: {message}", LogLevel.Information);
                //    break;

                #endregion

                default:
                    break;
            }
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
