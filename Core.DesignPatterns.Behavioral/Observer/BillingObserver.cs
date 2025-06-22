namespace Core.DesignPatterns.Behavioral.Observer
{
    public class BillingObserver : IObserver
    {
        public void Update(string eventData)
            => Console.WriteLine($"[Billing] Invoice generated for order: {eventData}");
    }
}
