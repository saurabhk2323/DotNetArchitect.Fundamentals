using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Composite
{
    public interface IOrderComponent
    {
        string Name { get; }
        decimal GetTotalPrice();
    }
}
