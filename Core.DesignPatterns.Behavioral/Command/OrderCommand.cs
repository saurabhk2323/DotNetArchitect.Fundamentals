namespace Core.DesignPatterns.Behavioral.Command
{
    public class OrderCommand : ICommand
    {
        private readonly string _orderId;
        private readonly string _productId;

        public OrderCommand(string orderId, string productId)
        {
            _orderId = orderId;
            _productId = productId;
        }

        public void Execute()
        {
            Console.WriteLine($"[OrderService] Order {_orderId} placed for {_productId}.");
        }
    }
}
