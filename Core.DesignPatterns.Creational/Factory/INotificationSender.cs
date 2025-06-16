using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DesignPatterns.Shared.Models;

namespace Core.DesignPatterns.Creational.Factory
{
    public interface INotificationSender
    {
        public void Send(Notification notification);
    }
}
