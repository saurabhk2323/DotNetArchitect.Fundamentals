# Factory Design Pattern (Simple Factory)

## 📜 Purpose

The **Factory** pattern (often implemented as a "Simple Factory" or "Static Factory" as shown in this example) provides a way to create objects without exposing the instantiation logic to the client. It defines an interface or abstract class for creating an object but lets subclasses (in classic Factory Method) or a dedicated factory class/method decide which class to instantiate.

This example demonstrates a **Simple Factory** where a static method in a factory class is responsible for creating objects based on input parameters.

## 🤔 When to Use

*   When a class cannot anticipate the class of objects it must create.
*   When a class wants its subclasses to specify the objects it creates (classic Factory Method).
*   When you want to centralize object creation logic for a family of related product types.
*   To decouple client code from concrete classes of the objects it needs to create. The client only interacts with the product interface and the factory.
*   When you want to provide a simpler way to create objects compared to direct instantiation, especially if the instantiation logic is complex or involves configuration.

## 🌟 .NET Analogy

*   **`System.Convert.ChangeType(object value, Type conversionType)`**: While not a direct class factory, it encapsulates the logic for converting an object to a specified type, similar to how a factory produces an object of a requested type.
*   **`System.Net.WebRequest.Create(string requestUriString)`**: This static method returns a `WebRequest` descendant (`HttpWebRequest`, `FtpWebRequest`, etc.) based on the URI scheme. The client doesn't need to know the concrete type.
*   **`Activator.CreateInstance(Type type)`**: Creates an instance of the specified type using that type's default constructor. It's a generic way to create objects when the type is known at runtime.
*   Many dependency injection frameworks use factory patterns internally to create and manage object instances.

## 🚀 Domain Scenario: Notification Sender Factory

In this example, we need to create different types of notification senders (e.g., for Email, SMS) based on a given requirement. Instead of having the client code directly instantiate `EmailSender` or `SmsSender`, we use a factory to handle this.

### ✨ Key Components:

*   **`INotificationSender` (Product Interface)**:
    *   Defines the common interface for all notification senders. It has a `Send(Notification notification)` method.
*   **`EmailSender`, `SmsSender` (Concrete Products)**:
    *   Concrete implementations of `INotificationSender` for sending Email and SMS notifications respectively.
*   **`NotificationFactory` (Simple Factory Class)**:
    *   A `static` class containing a `static` factory method: `GetSender(SenderType type)`.
    *   This method takes a `SenderType` enum (`email` or `sms`) as input.
    *   It uses a `switch` statement to decide which concrete sender object (`EmailSender` or `SmsSender`) to instantiate and return as an `INotificationSender`.
*   **`SenderType` (Enum)**:
    *   An enumeration (`Core.DesignPatterns.Shared.Enums.SenderType`) used to specify the desired type of sender.
*   **`Runner` (Client)**:
    *   The client code that needs an `INotificationSender`.
    *   It calls `NotificationFactory.GetSender()` with the desired `SenderType`.
    *   It then uses the returned `INotificationSender` to send a notification, without needing to know the concrete type of the sender.

### ⚙️ How it Works:

1.  The client (`Runner.Execute()`) needs to send a notification (e.g., an email).
2.  Instead of `new EmailSender()`, the client calls `NotificationFactory.GetSender(SenderType.email)`.
3.  The `NotificationFactory`'s `GetSender` method encapsulates the logic to create and return an `EmailSender` instance (cast to `INotificationSender`).
4.  The client receives an object that implements `INotificationSender` and can use its `Send` method.
5.  If the client later needs to send an SMS, it simply calls `NotificationFactory.GetSender(SenderType.sms)`.

This approach centralizes the creation logic within the `NotificationFactory`. If a new sender type (e.g., `PushNotificationSender`) is added, only the `NotificationFactory` and the `SenderType` enum need to be modified. The client code that uses the factory remains unchanged as long as it programs against the `INotificationSender` interface.

This pattern is simpler than the Abstract Factory or the classic Factory Method but still provides good decoupling between the client and concrete product classes.
