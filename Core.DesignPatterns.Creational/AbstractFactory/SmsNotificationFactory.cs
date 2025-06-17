namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public class SmsNotificationFactory : INotificationFactory
    {
        public INotificationSender CreateSender() => new SmsSender();
        public IMessageFormatter CreateMessageFormatter() => new SmsFormatter();
    }
}
