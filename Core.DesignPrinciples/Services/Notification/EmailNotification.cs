using Core.DesignPrinciples.Common;
namespace Core.DesignPrinciples.Services.Notification
{
    public class EmailNotification : NotificationSystem
    {
        private readonly ILogger<EmailNotification> _logger;

        public EmailNotification(ILogger<EmailNotification> logger) : base(logger)
        {
            _logger = logger;
        }

        public override void SendNotification(string message)
        {
            _logger.LogInformation($"Email notification sent: {message}", LogLevel.Information);
        }
    }
}
