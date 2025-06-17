using Core.DesignPatterns.Shared.Models;

namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public class SmsSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"[SMS] Sending: {notification.Message} to {notification.Recipient}");
        }
    }
}
