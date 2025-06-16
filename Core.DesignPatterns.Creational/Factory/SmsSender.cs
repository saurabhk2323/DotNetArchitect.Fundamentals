using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Factory
{
    internal class SmsSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"[SMS] Sent to {notification.Recipient}: {notification.Message}");
        }
    }
}
