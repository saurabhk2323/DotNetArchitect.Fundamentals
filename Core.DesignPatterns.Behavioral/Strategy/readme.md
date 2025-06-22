📘 Purpose:
To define a family of algorithms (or behaviors), encapsulate each one, and make them interchangeable at runtime.

🧠 When to Use:
When you have multiple ways of performing an operation (like different pricing models, sorting algorithms, notification channels).

When you want to avoid if-else or switch cases and let behavior vary independently from clients.

📚 .NET Analogy:
ILogger in ASP.NET Core: Different providers like ConsoleLogger, FileLogger, etc.

IComparer passed to List.Sort()

🛠️ Domain Scenario: Switching Notification Channels
Say your interface is:
INotificationStrategy --> Send(string to, string message);

You have two implementations:
	EmailNotification
	SmsNotification 

And your context looks like:
	NotificationService
		NotificationService(INotificationStrategy strategy)
		Notify(string to, string message)
Usage:
	NotificationService(new EmailNotification());
	NotificationService(new SmsNotification());

🎯 Interview Insight:
“We used the Strategy pattern to inject different notification delivery strategies (Email, SMS, Push) based on 
user preference or urgency level. This kept our notification service open for extension but closed for modification.”
