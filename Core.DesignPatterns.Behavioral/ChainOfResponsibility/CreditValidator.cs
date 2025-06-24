namespace Core.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class CreditValidator : OrderValidator
    {
        public override void Validate(Order order)
        {
            if (order.TotalPrice > 100000)
                Console.WriteLine("[CreditValidator] Credit limit exceeded");
            else
            {
                Console.WriteLine("[CreditValidator] Credit OK");
                _next?.Validate(order);
            }
        }
    }
}
