namespace Core.DesignPatterns.Behavioral.Strategy
{
    public class NotificationService
    {
        private readonly INotificationStrategy _strategy;

        public NotificationService(INotificationStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Notify(string to, string message)
        {
            _strategy.Send(to, message);
        }
    }
}
