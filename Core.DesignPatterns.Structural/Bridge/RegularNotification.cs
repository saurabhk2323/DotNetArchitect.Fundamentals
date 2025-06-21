using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Bridge
{
    public class RegularNotification : Notification
    {
        public RegularNotification(IMessageSender sender) : base(sender)
        {

        }
        public override void Notify(string to, string message)
        {
            _sender.Send(to, message);
        }
    }
}
