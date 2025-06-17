using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Adapter
{
    public class ExternalSmsService
    {
        public void SendSmsToUser(string mobileNumber, string content)
        {
            Console.WriteLine($"SMS sent to {mobileNumber}: {content}");
        }
    }
}
