using Core.DesignPrinciples.Common;
using Core.DesignPrinciples.Contracts;
using Core.DesignPrinciples.Models;

namespace Core.DesignPrinciples.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IInventoryService _inventoryService;

        // database is not configured for this projet, in memory role play for database
        private readonly IList<Order> _orders;

        public OrderService(ILogger<OrderService> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
            _orders = new List<Order>();
        }

        public void CreateOrder(CreateOrderDto createOrderDto)
        {
            if (createOrderDto == null) 
            {
                return;
            }

            if (createOrderDto?.OrderedProducts?.All(x => _inventoryService.CheckProductAvailability(x.Id, x.Quantity)) == false)
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
            order?.OrderedProducts?.ForEach(orderedProduct => _inventoryService.UpdateInventory(orderedProduct.Id, orderedProduct.Quantity));

            _logger.LogInformation($"Order is created - {order?.Id}", LogLevel.Information);
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
            }
            else
            {
                _logger.LogInformation($"Order not found: {orderId}");
            }
        }
    }
}
