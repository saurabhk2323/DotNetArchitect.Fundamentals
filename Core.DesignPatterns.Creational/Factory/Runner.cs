using Core.DesignPatterns.Shared.Enums;
using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Factory
{
    public class Runner
    {
        public static void Execute()
        {
            var email_notification = new Notification { Recipient = "saurabh@example.com", Message = "Order confirmed" };
            var sender = NotificationFactory.GetSender(SenderType.email);
            sender.Send(email_notification);
            var sms_notification = new Notification { Recipient = "+19876543", Message = "Order confirmed" };
            sender = NotificationFactory.GetSender(SenderType.sms);
            sender.Send(sms_notification);
        }
    }
}
