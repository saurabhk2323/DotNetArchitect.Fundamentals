using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Bridge
{
    public class SMSSender : IMessageSender
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"SMS to {to}: {message}");
        }
    }
}
