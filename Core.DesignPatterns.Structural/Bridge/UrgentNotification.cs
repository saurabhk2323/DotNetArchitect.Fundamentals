namespace Core.DesignPatterns.Structural.Bridge
{
    public class UrgentNotification : Notification
    {
        public UrgentNotification(IMessageSender sender) : base(sender)
        {
        }

        public override void Notify(string to, string message)
        {
            _sender.Send(to, "[URGENT] " + message);

            // implement retry for this critical notification

            // log this as a critical event
        }
    }
}
