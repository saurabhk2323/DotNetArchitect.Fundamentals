using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Adapter
{
    public class SmsNotificationAdapter : INotificationSender
    {
        private readonly ExternalSmsService _externalSmsService;

        public SmsNotificationAdapter(ExternalSmsService externalSmsService)
        {
            _externalSmsService = externalSmsService;
        }
        public void Send(string to, string message)
        {
            _externalSmsService.SendSmsToUser(to, message);
        }
    }
}
