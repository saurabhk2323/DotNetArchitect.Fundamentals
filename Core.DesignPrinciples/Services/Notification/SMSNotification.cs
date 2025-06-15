namespace Core.DesignPrinciples.Services.Notification
{
    public class SMSNotification: NotificationSystem
    {
        private readonly ILogger<SMSNotification> _logger;

        public SMSNotification(ILogger<SMSNotification> logger):base(logger)
        {
            _logger = logger;
        }

        public override void SendNotification(string message)
        {
            _logger.LogInformation($"SMS notification sent: {message}", LogLevel.Information);
        }
    }
}
