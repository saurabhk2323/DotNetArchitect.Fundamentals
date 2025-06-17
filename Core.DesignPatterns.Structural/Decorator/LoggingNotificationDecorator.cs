using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Decorator
{
    public class LoggingNotificationDecorator : INotificationSender
    {
        private readonly INotificationSender _inner;

        public LoggingNotificationDecorator(INotificationSender inner)
        {
            _inner = inner;
        }

        public void Send(string to, string message)
        {
            Console.WriteLine($"[LOG] Sending to {to}");
            _inner.Send(to, message);
            Console.WriteLine($"[LOG] Sent to {to}");
        }
    }
}
