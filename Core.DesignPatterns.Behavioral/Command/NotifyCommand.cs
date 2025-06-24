namespace Core.DesignPatterns.Behavioral.Command
{
    public class NotifyCommand : ICommand
    {
        private readonly string _recipient;
        private readonly string _message;

        public NotifyCommand(string recipient, string message)
        {
            _recipient = recipient;
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine($"[NotificationService] Sent to {_recipient}: {_message}");
        }
    }
}
