using Core.DesignPrinciples.Common;
using Core.DesignPrinciples.Models;

namespace Core.DesignPrinciples.Contracts
{
    /* IOrderService contains number of definitions, which are responsible for different jobs
     * Order creation, update & cancellation belongs to same category
     * SendNotification - There is relation between order processing, but notifications can be sent on different responsibilities as well like invoice generation, inventory updated, etc
     * Violating ISP; SRP
     */
    public interface IOrderService
    {
        void CreateOrder(CreateOrderDto createOrderDto);

        void UpdateOrder(UpdateOrderDto updateOrderDto);

        void CancelOrder(string orderId);
    }
}
