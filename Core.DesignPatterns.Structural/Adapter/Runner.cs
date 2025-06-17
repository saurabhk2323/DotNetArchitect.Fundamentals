using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Adapter
{
    public class Runner
    {
        public static void Execute()
        {
            INotificationSender notification = new SmsNotificationAdapter(new ExternalSmsService());
            notification.Send("9876543210", "Order #123 shipped!");
        }
    }
}
