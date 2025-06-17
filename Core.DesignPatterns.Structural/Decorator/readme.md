✅ Decorator Pattern
📘 Purpose:
Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending behavior.

🧠 When to Use:
You want to add functionality (e.g., logging, validation, retry) to individual objects at runtime.

Avoid bloating classes with multiple responsibilities.

📚 .NET Analogy:
ASP.NET Core Middleware Pipeline

HttpMessageHandler chain (e.g., LoggingHandler → RetryHandler)

🛠️ Domain Scenario: Enhance Notification
You want to:

Log every notification sent

Retry once on failure

Start with a base interface:

INotificationSender --> Send(to, message)

A basic implementation:

EmailSender --> Send(to, message)

✅ Add Logging Decorator:
LoggingNotificationDecorator --> LoggingNotificationDecorator(INotificationSender inner) --> Send(to, message) --> print logs, execute send, print logs

✅ Add Retry Decorator:
