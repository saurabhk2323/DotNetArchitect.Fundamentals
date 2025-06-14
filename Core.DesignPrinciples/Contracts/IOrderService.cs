using Core.DesignPrinciples.Common;
using Core.DesignPrinciples.Models;

namespace Core.DesignPrinciples.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderDto createOrderDto);

        void UpdateOrder(UpdateOrderDto updateOrderDto);

        void CancelOrder(string orderId);

        void SendNotification(NotificationType type, string message);

        public void UpdateInventory(string? productId, int quantity);

        public bool CheckProductAvailability(string? productId, int quantity);

    }
}
