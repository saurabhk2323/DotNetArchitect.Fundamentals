namespace Core.DesignPatterns.Behavioral.Strategy
{
    public class EmailNotification : INotificationStrategy
    {
        public void Send(string to, string message)
            => Console.WriteLine($"[EMAIL] {to}: {message}");
    }
}
