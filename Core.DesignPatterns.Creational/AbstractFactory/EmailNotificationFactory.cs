namespace Core.DesignPatterns.Creational.AbstractFactory
{
    public class EmailNotificationFactory : INotificationFactory
    {
        public INotificationSender CreateSender() => new EmailSender();
        public IMessageFormatter CreateMessageFormatter() => new EmailFormatter();
    }
}
