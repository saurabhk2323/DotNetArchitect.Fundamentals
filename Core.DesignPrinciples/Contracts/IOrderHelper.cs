using Core.DesignPrinciples.Models;

namespace Core.DesignPrinciples.Contracts
{
    public interface IOrderHelper
    {
        void CreateOrder(CreateOrderDto createOrderDto);

        void UpdateOrder(UpdateOrderDto updateOrderDto);

        void CancelOrder(string orderId);
    }
}
