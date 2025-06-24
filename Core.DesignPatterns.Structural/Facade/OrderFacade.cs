using Core.DesignPatterns.Shared.Models;

namespace Core.DesignPatterns.Structural.Facade
{
    public class OrderFacade
    {
        public void PlaceOrder(Product product, string userEmail)
        {
            InventoryService.Reserve(product.Id);
            PaymentService.Charge(product.Price);
            NotificationService.SendOrderConfirmation(userEmail);
            ShippingService.Dispatch(product.Id);
        }
    }
}
