namespace Core.DesignPrinciples.Models
{
    public class Order
    {
        public string? Id { get; set; }
        public decimal TotalAmount { get; set; }
        public int Total { get; set; }
        public List<OrderedProduct>? OrderedProducts { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public void CalculateTotalAmount() => TotalAmount = OrderedProducts?.Any() == true ? OrderedProducts.Sum(p => p.Quantity * p.Price) : 0;

        public void CalculateTotalCount() => Total = OrderedProducts?.Any() == true ? OrderedProducts.Sum(p => p.Quantity) : 0;
    }
}
