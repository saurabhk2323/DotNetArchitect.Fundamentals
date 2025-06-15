using Core.DesignPrinciples.Contracts;

namespace Core.DesignPrinciples.Services.Notification
{
    /*NotificationSystem has implemented INotificationSystem
     There is a function - SendNotification
    - The Notification System is acting as a base class
    - EmailNotification, SMSNotification, PushNotification - Children
    - If we are using INotificationSystem as DI inside a class, then from there how to call a specific children function
    - 
     */
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
