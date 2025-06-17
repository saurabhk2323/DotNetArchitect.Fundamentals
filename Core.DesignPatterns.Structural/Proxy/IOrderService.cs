using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Proxy
{
    public interface IOrderService
    {
        public Order GetOrder(int orderId);
    }
}
