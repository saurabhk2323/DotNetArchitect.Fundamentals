namespace Core.DesignPrinciples.Services.Notification
{
    public class PushNotification: NotificationSystem
    {
        private readonly ILogger<PushNotification> _logger;

        public PushNotification(ILogger<PushNotification> logger):base(logger)
        {
            _logger = logger;
        }

        public override void SendNotification(string message)
        {
            _logger.LogInformation($"Push notification sent: {message}", LogLevel.Information);
        }
    }
}
