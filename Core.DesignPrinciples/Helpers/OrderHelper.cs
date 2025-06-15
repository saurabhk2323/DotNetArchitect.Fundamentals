using Core.DesignPrinciples.Common;
using Core.DesignPrinciples.Contracts;
using Core.DesignPrinciples.Models;
using Core.DesignPrinciples.Services.Notification;

namespace Core.DesignPrinciples.Helpers
{
    public class OrderHelper : IOrderHelper
    {
        private readonly ILogger<OrderHelper> _logger;
        private readonly IOrderService _orderService;
        private readonly INotificationSystemFactory _notificationSystemFactory;

        public OrderHelper(ILogger<OrderHelper> logger, IOrderService orderService, INotificationSystemFactory notificationSystemFactory)
        {
            _logger = logger;
            _orderService = orderService;
            _notificationSystemFactory = notificationSystemFactory;
        }

        public void CancelOrder(string orderId)
        {
            _logger.LogInformation("Order cancellation request initiated for {orderId}", orderId);
            _orderService.CancelOrder(orderId);
            _notificationSystemFactory.GetImplementation(NotificationType.email).SendNotification($"{orderId} order is cancelled");
        }

        public void CreateOrder(CreateOrderDto createOrderDto)
        {
            _logger.LogInformation("Creating a new order: {order}", createOrderDto);
            _orderService.CreateOrder(createOrderDto);
            _notificationSystemFactory.GetImplementation(NotificationType.sms).SendNotification("Order is created");
            _notificationSystemFactory.GetImplementation(NotificationType.email).SendNotification("Order is created");
        }

        public void UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            _logger.LogInformation("Updating an existing order: {order}", updateOrderDto);
            _orderService.UpdateOrder(updateOrderDto);
            _notificationSystemFactory.GetImplementation(NotificationType.email).SendNotification($"{updateOrderDto.Id} order is updated");
            _notificationSystemFactory.GetImplementation(NotificationType.sms).SendNotification($"{updateOrderDto.Id} order is updated");
            _notificationSystemFactory.GetImplementation(NotificationType.push).SendNotification($"{updateOrderDto.Id} order is updated");
        }
    }
}
