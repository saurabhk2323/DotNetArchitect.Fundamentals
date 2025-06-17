namespace Core.DesignPatterns.Structural.Facade
{
    public class NotificationService
    {
        public static void SendOrderConfirmation(string email) =>
            Console.WriteLine($"[Notification] Email sent to {email}");
    }
}
