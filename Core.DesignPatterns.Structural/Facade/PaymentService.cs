namespace Core.DesignPatterns.Structural.Facade
{
    public class PaymentService
    {
        public static void Charge(decimal amount) =>
            Console.WriteLine($"[Payment] Charged Rs.{amount}");
    }
}
