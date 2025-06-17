using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Decorator
{
    public class RetryNotificationDecorator : INotificationSender
    {
        private readonly INotificationSender _inner;

        public RetryNotificationDecorator(INotificationSender inner)
        {
            _inner = inner;
        }
        public void Send(string to, string message)
        {
            try
            {
                _inner.Send(to, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Retrying after failure: " + ex.Message);
                _inner.Send(to, message); // Retry once
            }
        }
    }
}
