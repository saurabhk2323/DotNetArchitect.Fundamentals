namespace Core.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class StockValidator : OrderValidator
    {
        public override void Validate(Order order)
        {
            if (order.ProductQuantity > 10)
                Console.WriteLine($"[StockValidator]  Not enough stock for {order.ProductName}");
            else
            {
                Console.WriteLine("[StockValidator] Stock available");
                _next?.Validate(order);
            }
        }
    }
}
