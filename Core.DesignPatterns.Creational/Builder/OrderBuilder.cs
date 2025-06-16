using Core.DesignPatterns.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Builder
{
    public class OrderBuilder
    {
        private readonly Order _order = new();

        public OrderBuilder AddProduct(Product product)
        {
            _order.Products.Add(product);
            return this;
        }

        public OrderBuilder AddProducts(IEnumerable<Product> products)
        {
            _order.Products.AddRange(products);
            return this;
        }

        public Order Build() => _order;
    }
}
