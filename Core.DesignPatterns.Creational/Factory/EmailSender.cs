using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Factory
{
    internal class EmailSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"[Email] Sent to {notification.Recipient}: {notification.Message}");
        }
    }
}
