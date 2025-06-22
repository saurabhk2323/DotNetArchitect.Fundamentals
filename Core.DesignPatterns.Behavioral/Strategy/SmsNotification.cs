namespace Core.DesignPatterns.Behavioral.Strategy
{
    public class SmsNotification : INotificationStrategy
    {
        public void Send(string to, string message)
            => Console.WriteLine($"[SMS] {to}: {message}");
    }
}
