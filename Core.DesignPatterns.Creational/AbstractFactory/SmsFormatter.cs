namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public class SmsFormatter : IMessageFormatter
    {
        public string Format(string message) => $"SMS::{message}";
    }
}
