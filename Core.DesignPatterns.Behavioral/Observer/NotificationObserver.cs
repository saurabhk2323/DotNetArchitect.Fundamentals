namespace Core.DesignPatterns.Behavioral.Observer
{
    public class NotificationObserver : IObserver
    {
        public void Update(string eventData)
            => Console.WriteLine($"[Notification] Email sent for order: {eventData}");
    }
}
