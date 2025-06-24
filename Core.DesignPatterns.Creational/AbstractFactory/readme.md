# Abstract Factory Design Pattern

## 📜 Purpose

The **Abstract Factory** pattern provides an interface for creating *families of related or dependent objects* without specifying their concrete classes. It's like a factory of factories, where the main factory delegates object creation to other specialized factories.

This pattern is particularly useful when the system needs to be independent of how its products are created, composed, and represented. It allows you to create objects that are grouped by a common theme (e.g., UI elements for different operating systems, or notification components for different channels).

## 🤔 When to Use

*   When your system needs to create families of related products (objects) but you want to ensure that the products from one family are used together and are compatible.
*   When you want to provide a library of products and you want to expose only their interfaces, not their implementations.
*   When you need to configure your system with one of multiple families of products. For example, switching between a "dark mode" and "light mode" theme, where each theme has its own set of UI components (buttons, text boxes, etc.).
*   To isolate concrete classes from the client. The client code works with abstract interfaces for both the factory and the products.

## 🌟 .NET Analogy

*   **`System.Data.Common.DbProviderFactory`**: This class in ADO.NET is an excellent example. It allows you to create database-specific objects (like `DbConnection`, `DbCommand`, `DbDataAdapter`) without knowing the concrete database provider (SQL Server, Oracle, MySQL) at compile time. You get a factory for a specific provider, and that factory then creates compatible database objects.
*   UI toolkits that support multiple look-and-feels often use this pattern.

## 🚀 Domain Scenario: Notification System

In this example, we're building a notification system that can send messages via different channels (e.g., Email, SMS). Each channel might require:
1.  A specific **sender** mechanism (`INotificationSender`).
2.  A specific **message formatter** (`IMessageFormatter`) to prepare the content appropriately for that channel.

The Abstract Factory pattern helps us create these related objects (sender and formatter) together for a chosen notification channel.

### ✨ Key Components:

*   **`INotificationFactory` (Abstract Factory)**:
    *   Declares methods to create abstract product objects: `CreateSender()` and `CreateMessageFormatter()`.
*   **`EmailNotificationFactory`, `SmsNotificationFactory` (Concrete Factories)**:
    *   Implement `INotificationFactory` to create families of concrete products.
    *   `EmailNotificationFactory` creates `EmailSender` and `EmailFormatter`.
    *   `SmsNotificationFactory` creates `SmsSender` and `SmsFormatter`.
*   **`INotificationSender`, `IMessageFormatter` (Abstract Products)**:
    *   Define interfaces for the types of product objects that the factories can create.
*   **`EmailSender`, `SmsSender`, `EmailFormatter`, `SmsFormatter` (Concrete Products)**:
    *   Concrete implementations of the product interfaces for specific channels.
    *   `EmailFormatter` might wrap the message in HTML.
    *   `SmsFormatter` might prefix the message with "SMS::".
*   **`Runner` (Client)**:
    *   Uses an `INotificationFactory` (e.g., `EmailNotificationFactory`) to get the necessary sender and formatter without knowing the concrete types.
    *   This decouples the client from the specific implementation details of how email or SMS notifications are formatted and sent.

### ⚙️ How it Works:

1.  The client (`Runner.Execute()`) decides which type of notification it wants to send (e.g., Email).
2.  It obtains the corresponding concrete factory (e.g., `new EmailNotificationFactory()`).
3.  It calls the factory's methods (`CreateMessageFormatter()`, `CreateSender()`) to get the product objects (an `EmailFormatter` and an `EmailSender`).
4.  The client then uses these product objects to format the message and send the notification.

This ensures that an `EmailSender` is always used with an `EmailFormatter`, and an `SmsSender` with an `SmsFormatter`, maintaining consistency within the product family. If we were to add a "Push Notification" channel, we would create a `PushNotificationFactory`, `PushSender`, and `PushFormatter`, and the client code could easily switch to using it without major changes.
