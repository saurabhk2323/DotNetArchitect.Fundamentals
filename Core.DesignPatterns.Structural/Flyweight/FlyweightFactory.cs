namespace Core.DesignPatterns.Structural.Flyweight
{
    public class FlyweightFactory
    {
        private readonly Dictionary<string, ProductFlyweight> _flyweights = new();

        public ProductFlyweight GetFlyweight(string brand, string category, string warranty)
        {
            string key = $"{brand}:{category}:{warranty}";

            if (!_flyweights.ContainsKey(key))
            {
                Console.WriteLine($"[FlyweightFactory] Creating new flyweight for {key}");
                _flyweights[key] = new ProductFlyweight(brand, category, warranty);
            }

            return _flyweights[key];
        }
    }
}
