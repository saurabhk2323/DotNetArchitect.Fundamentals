1. ✅ Adapter Pattern
📘 Purpose:
To convert the interface of a class into one that the client expects. It allows integration with incompatible interfaces.

🧠 When to Use:
Using third-party or legacy services that don’t match your current app interface.

You want to plug and play external libraries with zero change in your app logic.

📚 .NET Analogy:
StreamReader adapts Stream.

XmlReader.Create() adapts multiple stream-based sources.

🛠️ Domain Scenario: Integrating SMS provider
Let’s say you use this interface in your system:
INotificationSender ---> Send(to, message)

And the external SMS API
ExternalSmsService --> SendSmsToUser(mobileNumber, message)

Solution:
The client doesn't know how external service is accepting parameters, or how its connection service is working
Also, tomorrow a new external service for message service can replace.
In this case, let's create an adapter for the send sms service, and here consume the external sms service

SmsNotificationAdapter  --> Send(to, message)

