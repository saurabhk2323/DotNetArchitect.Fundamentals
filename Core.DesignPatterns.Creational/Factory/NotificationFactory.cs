using Core.DesignPatterns.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Factory
{
    public static class NotificationFactory
    {
        public static INotificationSender GetSender(SenderType type)
        {
            return type switch
            { 
                SenderType.email => new EmailSender(),
                SenderType.sms => new SmsSender(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
