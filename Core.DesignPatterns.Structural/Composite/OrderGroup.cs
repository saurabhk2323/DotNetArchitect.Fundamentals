using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Structural.Composite
{
    public class OrderGroup : IOrderComponent
    {
        public string Name { get; }

        private readonly List<IOrderComponent> _components = new();

        public OrderGroup(string name)
        {
            Name = name;
        }

        public void AddComponent(IOrderComponent component)
        {
            _components.Add(component);
        }

        public decimal GetTotalPrice()
        {
            return _components.Sum(c => c.GetTotalPrice());
        }

        public void ApplyDiscount(decimal percentage)
        {
            foreach (var item in _components)
            {
                item.ApplyDiscount(percentage);
            }
        }

        public string GenerateInvoice()
        {
            var invoiceLines = _components.Select(i => i.GenerateInvoice());
            return $"[Bundle: {Name}]\n" + string.Join("\n", invoiceLines);
        }
    }
}
