using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Bridge
{
    public interface IMessageSender
    {
        void Send(string to, string message);
    }
}
