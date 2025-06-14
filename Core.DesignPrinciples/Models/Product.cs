namespace Core.DesignPrinciples.Models
{
    public class Product
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
