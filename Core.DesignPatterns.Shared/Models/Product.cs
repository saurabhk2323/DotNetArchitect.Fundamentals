using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Shared.Models
{
    public class Product:ICloneable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public Object Clone()
        {
            return new Product { Id = this.Id, Name = this.Name, Price = this.Price };
        }
    }
}
