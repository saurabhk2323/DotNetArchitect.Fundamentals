namespace Core.DesignPatterns.Structural.Flyweight
{
    public class OrderItem
    {
        public string ProductName { get; }
        public decimal Price { get; }

        private readonly ProductFlyweight _flyweight;

        public OrderItem(string name, decimal price, ProductFlyweight flyweight)
        {
            ProductName = name;
            Price = price;
            _flyweight = flyweight;
        }

        public void PrintDetails()
        {
            _flyweight.Display(ProductName, Price);
        }
    }
}
