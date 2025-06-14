namespace Core.DesignPrinciples.Models
{
    public class UpdateOrderDto
    {
        public string? Id { get; set; }
        public List<OrderedProduct>? OrderedProducts { get; set; }
    }
}
