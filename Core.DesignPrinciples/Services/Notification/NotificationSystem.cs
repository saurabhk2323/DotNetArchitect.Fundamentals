using Core.DesignPrinciples.Contracts;

namespace Core.DesignPrinciples.Services.Notification
{
    public class NotificationSystem: INotificationSystem
    {
        private readonly ILogger<NotificationSystem> _logger;

        public NotificationSystem(ILogger<NotificationSystem> logger)
        {
            _logger = logger;
        }

        public virtual void SendNotification(string message)
        {
            _logger.LogInformation($"Send Notification: {message}", LogLevel.Information);
        }
    }
}
