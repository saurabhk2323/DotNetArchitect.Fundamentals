using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public interface INotificationFactory
    {
        INotificationSender CreateSender();
        IMessageFormatter CreateMessageFormatter();
    }
}
