namespace Core.DesignPrinciples.Models
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public int Total { get; set; }
        public List<OrderedProduct>? OrderedProducts { get; set; }
    }
}
