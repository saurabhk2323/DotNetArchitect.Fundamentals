using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Behavioral.Strategy
{
    public class Runner
    {
        /*
         “We used the Strategy pattern to inject different notification delivery strategies (Email, SMS, Push) 
        based on user preference or urgency level. 
        This kept our notification service open for extension but closed for modification.”
         */
        public static void Execute()
        {
            var emailService = new NotificationService(new EmailNotification());
            emailService.Notify("saurabh@example.com", "Order confirmed");

            var smsService = new NotificationService(new SmsNotification());
            smsService.Notify("+919876543210", "Order Shipped!");
        }
    }
}
