using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Proxy
{
    public class CachedOrderProxy : IOrderService
    {
        private readonly IOrderService _realOrderService;
        private readonly Dictionary<int, Order> _cache = new();

        public CachedOrderProxy(IOrderService realOrderService)
        {
            _realOrderService = realOrderService;
        }
        public Order GetOrder(int orderId)
        {
            // check the cache
            if (_cache.ContainsKey(orderId)) 
            {
                Console.WriteLine("Returned from cache.");
                return _cache[orderId];
            }
            // not found in cache
            var order = _realOrderService.GetOrder(orderId); // retrieve from database
            _cache[orderId] = order; // save into cache
            return order;
        }
    }
}
