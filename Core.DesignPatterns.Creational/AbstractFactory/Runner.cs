using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public class Runner
    {
        public static void Execute()
        {
            SendNotification(new EmailNotificationFactory(), "saurabh@example.com", "Order received!");
            SendNotification(new SmsNotificationFactory(), "+911234567890", "Your OTP is 1234");
        }

        private static void SendNotification(INotificationFactory factory, string recipient, string rawMessage)
        {
            var formatter = factory.CreateMessageFormatter();
            var sender = factory.CreateSender();
            var message = formatter.Format(rawMessage);

            sender.Send(new Notification { Recipient = recipient, Message = message });
        }
    }
}
