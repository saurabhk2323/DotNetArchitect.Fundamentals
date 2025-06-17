namespace Core.DesignPatterns.Shared.Models
{
    public class Order:ICloneable
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new();
        public bool IsGift { get; set; }
        public decimal DiscountPercentage { get; set; } = 0;
        public string ShippingType { get; set; } = "Standard";
        public string? PromoCode { get; set; }
        public string? PaymentMethod { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal total = Products.Sum(p => p.Price);
                if (DiscountPercentage > 0)
                {
                    total -= total * (DiscountPercentage / 100);
                }
                return total;
            }
        }

        public object Clone()
        {
            return new Order
            {
                Id = this.Id,
                IsGift = this.IsGift,
                DiscountPercentage = this.DiscountPercentage,
                ShippingType = this.ShippingType,
                PromoCode = this.PromoCode,
                PaymentMethod = this.PaymentMethod,
                Products = this.Products.Select(p => (Product) p.Clone()).ToList()
            };
        }
    }
}
