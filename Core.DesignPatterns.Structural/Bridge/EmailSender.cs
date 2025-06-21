namespace Core.DesignPatterns.Structural.Bridge
{
    public class EmailSender : IMessageSender
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Email to {to}: {message}");
        }
    }
}
