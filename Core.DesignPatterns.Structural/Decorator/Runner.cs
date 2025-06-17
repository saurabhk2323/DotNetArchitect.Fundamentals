using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Decorator
{
    public class Runner
    {
        public static void Execute()
        {
            INotificationSender sender = new EmailSender();
            RetryNotificationDecorator retryWrapper = new RetryNotificationDecorator(sender);
            LoggingNotificationDecorator loggingWrapper = new LoggingNotificationDecorator(retryWrapper);
            loggingWrapper.Send("user@example.com", "Your product shipped.");
        }
    }
}
