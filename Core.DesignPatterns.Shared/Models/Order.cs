namespace Core.DesignPatterns.Shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new();
        public decimal TotalPrice => Products.Sum(p => p.Price);
    }
}
