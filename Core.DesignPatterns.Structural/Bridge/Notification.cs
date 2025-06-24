namespace Core.DesignPatterns.Structural.Bridge
{
    public abstract class Notification
    {
        protected readonly IMessageSender _sender;
        protected Notification(IMessageSender sender) => _sender = sender;
        public abstract void Notify(string to, string message);
    }
}
