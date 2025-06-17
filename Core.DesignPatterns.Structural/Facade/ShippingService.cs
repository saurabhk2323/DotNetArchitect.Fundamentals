namespace Core.DesignPatterns.Structural.Facade
{
    public class ShippingService
    {
        public static void Dispatch(int productId) =>
            Console.WriteLine($"[Shipping] Dispatched product ID {productId}");
    }
}
