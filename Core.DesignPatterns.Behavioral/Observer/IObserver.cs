using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Behavioral.Observer
{
    public interface IObserver
    {
        void Update(string eventData);
    }
}
