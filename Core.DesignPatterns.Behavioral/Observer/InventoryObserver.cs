namespace Core.DesignPatterns.Behavioral.Observer
{
    public class InventoryObserver : IObserver
    {
        public void Update(string eventData)
            => Console.WriteLine($"[Inventory] Adjusting stock for order: {eventData}");
    }
}
