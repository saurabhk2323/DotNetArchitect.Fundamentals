using Core.DesignPrinciples.Common;
using Core.DesignPrinciples.Contracts;

namespace Core.DesignPrinciples.Services.Notification
{
    public class NotificationSystemFactory : INotificationSystemFactory
    {
        private readonly IServiceProvider _sp;

        public NotificationSystemFactory(IServiceProvider sp)
        {
            _sp = sp;
        }

        public INotificationSystem GetImplementation(NotificationType type)
        {
            return type switch
            {
                NotificationType.email => _sp.GetRequiredService<EmailNotification>(),
                NotificationType.sms => _sp.GetRequiredService<SMSNotification>(),
                NotificationType.push => _sp.GetRequiredService<PushNotification>(),
                _ => throw new ArgumentException("Invalid type")
            };
        }
    }
}
