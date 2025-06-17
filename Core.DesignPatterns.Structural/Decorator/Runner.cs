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
            LoggingNotificationDecorator loggingWrapper = new LoggingNotificationDecorator(sender);
            loggingWrapper.Send("user@example.com", "Your product shipped.");
        }
    }
}
