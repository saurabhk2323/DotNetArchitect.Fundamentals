using Core.DesignPatterns.Shared.Models;

namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public class EmailSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"[EMAIL] Sending: {notification.Message} to {notification.Recipient}");
        }
    }
}
