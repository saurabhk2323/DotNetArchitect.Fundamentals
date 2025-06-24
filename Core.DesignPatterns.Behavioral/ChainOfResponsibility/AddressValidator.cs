namespace Core.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class AddressValidator : OrderValidator
    {
        public override void Validate(Order order)
        {
            if (string.IsNullOrWhiteSpace(order.ShippingAddress))
                Console.WriteLine("[AddressValidator] Shipping address missing");
            else
            {
                Console.WriteLine("[AddressValidator] Address valid");
                _next?.Validate(order);
            }
        }
    }
}
