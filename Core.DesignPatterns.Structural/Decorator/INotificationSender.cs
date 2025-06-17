using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Decorator
{
    public interface INotificationSender
    {
        void Send(string to, string message);
    }
}
