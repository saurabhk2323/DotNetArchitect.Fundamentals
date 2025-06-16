namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public class EmailFormatter : IMessageFormatter
    {
        public string Format(string message) => $"<html><body>{message}</body></html>";
    }
}
