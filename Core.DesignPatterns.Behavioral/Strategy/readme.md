# Strategy Design Pattern 📜

## 📜 Purpose
The **Strategy** pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it. This allows a client to choose an algorithm from a family of algorithms at runtime without altering the client's code.

## 🤔 When to Use
*   When you have multiple related classes that differ only in their behavior. Strategy provides a way to configure a class with one of many behaviors.
*   When you need different variants of an algorithm. For example, different sorting algorithms, different data compression techniques, or different payment methods.
*   When you want to avoid exposing complex, algorithm-specific data structures to the client.
*   When a class defines many behaviors, and these appear as multiple conditional statements (if-else or switch) in its operations. Strategy moves these branches into their own strategy classes.
*   To achieve loose coupling between the context (the class using the strategy) and the concrete strategies.

## 🌟 .NET Analogy
*   **`System.Collections.Generic.List<T>.Sort(IComparer<T> comparer)`**: The `List<T>.Sort()` method can take an `IComparer<T>` implementation. This `IComparer<T>` is a strategy that defines how to compare two elements, allowing you to sort the list in different ways (e.g., ascending, descending, by different properties).
*   **ASP.NET Core Authentication Handlers (`IAuthenticationHandler`)**: Different authentication schemes (like JWT Bearer, Cookies, OAuth) are implemented as strategies. The authentication middleware uses the configured strategy to handle authentication.
*   **ASP.NET Core Logging Providers (`ILoggerProvider`)**: Different logging outputs (Console, Debug, File, Application Insights) are implemented as strategies. The logging framework uses the configured providers.
*   **LINQ's `Enumerable.OrderBy` / `ThenBy` methods with custom `IComparer<T>`**.

## 🚀 Domain Scenario: 🛒 Switching Notification Channels
In this example, an application needs to send notifications to users, but the method of notification (e.g., Email, SMS) can vary. Instead of hardcoding the notification logic or using conditional statements within a single service, we use the Strategy pattern to define different notification methods that can be selected at runtime.

### ✨ Key Components:
*   **`INotificationStrategy` (Strategy Interface)**:
    *   Declares a common interface for all supported notification algorithms (strategies).
    *   Defines a method `Send(string to, string message)`.
*   **Concrete Strategies**:
    *   **`EmailNotification`**: Implements `INotificationStrategy`. Its `Send()` method simulates sending an email.
    *   **`SmsNotification`**: Implements `INotificationStrategy`. Its `Send()` method simulates sending an SMS.
*   **`NotificationService` (Context)**:
    *   Maintains a reference to an `INotificationStrategy` object. This reference is typically set via the constructor (dependency injection).
    *   Has a method `Notify(string to, string message)` that delegates the actual sending logic to the currently configured strategy object by calling its `Send()` method.
*   **`Runner` (Client)**:
    *   Decides which notification strategy to use.
    *   Creates an instance of a concrete strategy (e.g., `new EmailNotification()`).
    *   Creates an instance of `NotificationService` (Context), injecting the chosen strategy.
    *   Calls the `Notify()` method on the `NotificationService` instance.

### ⚙️ How it Works:
1.  The client (`Runner`) needs to send a notification. It decides which strategy is appropriate (e.g., email for order confirmation, SMS for urgent alerts).
2.  The client creates an instance of the desired concrete strategy (e.g., `new EmailNotification()`).
3.  The client then creates an instance of the `NotificationService` (Context) and passes the chosen strategy object to its constructor. The `NotificationService` stores this strategy.
4.  When the client calls `notificationService.Notify(...)`, the `NotificationService` delegates this call to the `Send()` method of the strategy object it holds.
5.  If `EmailNotification` was injected, the email sending logic is executed. If `SmsNotification` was injected, SMS logic is executed.

This allows the `NotificationService` to remain unaware of the specific notification mechanism. New notification strategies (e.g., `PushNotificationStrategy`) can be added easily by creating a new class that implements `INotificationStrategy`, without modifying the `NotificationService` or existing strategies. The client can then choose to use this new strategy.
