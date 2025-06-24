namespace Core.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public abstract class OrderValidator
    {
        protected OrderValidator _next;

        public void SetNext(OrderValidator next) => _next = next;

        public abstract void Validate(Order order);
    }
}
