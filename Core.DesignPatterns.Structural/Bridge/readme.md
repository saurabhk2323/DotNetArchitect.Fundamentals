# Bridge Design Pattern 🌉

## 📜 Purpose
The **Bridge** pattern decouples an abstraction from its implementation so that the two can vary independently. It involves creating two separate hierarchies—one for abstractions and one for implementations—and then "bridging" them by composition. This allows you to combine different abstractions with different implementations at runtime.

It's particularly useful when you have a class hierarchy that tends to grow in two independent dimensions, leading to a combinatorial explosion of subclasses if not managed.

## 🤔 When to Use
*   When you want to avoid a permanent binding between an abstraction and its implementation. This might be the case, for example, when the implementation must be selected or switched at runtime.
*   When both the abstractions and their implementations can have their own extensible hierarchies.
*   When changes in the implementation of an abstraction should have no impact on clients; that is, their code should not have to be recompiled.
*   When you have a proliferation of classes resulting from a coupled interface and numerous implementations. The Bridge pattern helps manage this complexity by splitting one class hierarchy into two.
*   When you want to share an implementation among multiple objects (perhaps using reference counting) and this fact should be hidden from the client.

## 🌟 .NET Analogy
*   **ADO.NET `DbConnection` and Providers**: `DbConnection` is an abstraction for a database connection. Specific providers (like `SqlConnection` for SQL Server, `NpgsqlConnection` for PostgreSQL) are concrete implementations. While not a perfect Bridge in its purest form (as `SqlConnection` inherits `DbConnection`), the concept of separating the general connection abstraction from provider-specific implementation details is similar. A truer Bridge might involve `DbConnection` holding an `IDbProviderImplementation` interface.
*   **Drawing APIs**: A common example is having abstract shape classes (Circle, Square) that need to be drawn using different drawing APIs (e.g., DirectX, OpenGL, Skia). The shapes are the abstraction, and the drawing APIs are the implementations. The Bridge pattern allows you to draw any shape with any API without creating `DirectXCircle`, `OpenGLCircle`, etc.
*   **Cross-Platform UI Frameworks**: UI elements (Button, TextBox) are abstractions. The rendering logic for different operating systems (Windows, macOS, Linux) are implementations. The Bridge pattern allows UI elements to be rendered on any platform.

## 🚀 Domain Scenario: 📨 Sending Different Types of Notifications via Multiple Channels
Consider a system that needs to send various types of notifications (e.g., Regular, Urgent, Promotional) through different channels (e.g., Email, SMS).

Without Bridge, you might end up with classes like:
*   `RegularEmailNotification`, `UrgentEmailNotification`, `PromotionalEmailNotification`
*   `RegularSmsNotification`, `UrgentSmsNotification`, `PromotionalSmsNotification`

This leads to a class explosion (N types × M channels = N*M classes). The Bridge pattern helps by separating the notification *type* (abstraction) from the notification *sending mechanism* (implementation).

### ✨ Key Components:
*   **`Notification` (Abstraction)**:
    *   An abstract class that defines the high-level interface for notifications.
    *   It holds a reference to an `IMessageSender` object (the implementor). This reference is the "bridge".
    *   Declares an abstract method `Notify(string to, string message)`.
*   **Refined Abstractions (`RegularNotification`, `UrgentNotification`, `PromotionalNotification`)**:
    *   Subclasses of `Notification`.
    *   Each implements the `Notify` method, possibly adding specific logic related to its type (e.g., `UrgentNotification` might add "[URGENT]" prefix or include retry logic).
    *   They delegate the actual sending to the `_sender` (implementor) object.
*   **`IMessageSender` (Implementor Interface)**:
    *   Defines the interface for the implementation classes (sending mechanisms).
    *   Declares a method `Send(string to, string message)`.
*   **Concrete Implementors (`EmailSender`, `SMSSender`)**:
    *   Implement the `IMessageSender` interface.
    *   `EmailSender` provides logic to send a message via email.
    *   `SMSSender` provides logic to send a message via SMS.
*   **`Runner` (Client)**:
    *   Decides which combination of refined abstraction (notification type) and concrete implementor (sending channel) to use.
    *   Creates an instance of a refined abstraction (e.g., `UrgentNotification`) and injects an instance of a concrete implementor (e.g., `new SMSSender()`) into its constructor.
    *   Calls the `Notify` method on the abstraction object.

### ⚙️ How it Works:
1.  The client (`Runner`) wants to send, for example, an urgent notification via SMS.
2.  It creates an `SMSSender` object (concrete implementor).
3.  It then creates an `UrgentNotification` object (refined abstraction), passing the `SMSSender` to its constructor. The `UrgentNotification` object holds this `SMSSender` instance via its `_sender` field (the bridge).
4.  The client calls `urgentSms.Notify("...", "...")`.
5.  The `UrgentNotification.Notify` method executes its specific logic (e.g., formatting the message for urgency) and then calls `_sender.Send(...)` on the `SMSSender` instance it holds.
6.  The `SMSSender` then performs the actual SMS sending operation.

This allows you to:
*   Add new notification types (e.g., `ScheduledNotification`) by subclassing `Notification` without changing any sender code.
*   Add new sending channels (e.g., `PushNotificationSender`) by implementing `IMessageSender` without changing any notification type code.
The two hierarchies can evolve independently, providing great flexibility.