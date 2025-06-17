using Core.DesignPatterns.Shared.Models;

namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public interface INotificationSender
    {
        void Send(Notification notification);
    }

}
