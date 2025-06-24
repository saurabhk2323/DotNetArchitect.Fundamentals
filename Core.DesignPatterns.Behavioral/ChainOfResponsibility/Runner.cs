namespace Core.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class Runner
    {
        public static void Execute()
        {
            var order = new Order
            {
                OrderId = "ORD500",
                ProductName = "Laptop",
                ProductQuantity = 2,
                TotalPrice = 95000,
                ShippingAddress = "Bangalore"
            };

            // Build the chain
            var stock = new StockValidator();
            var credit = new CreditValidator();
            var address = new AddressValidator();

            stock.SetNext(credit);
            credit.SetNext(address);

            stock.Validate(order);
        }
    }
}
