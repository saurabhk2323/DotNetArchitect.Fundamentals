# Decorator Design Pattern 🎁

## 📜 Purpose
The **Decorator** pattern attaches additional responsibilities or behaviors to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality. The decorator object wraps the original object, providing the same interface but adding its own behavior either before or after delegating the call to the wrapped object.

## 🤔 When to Use
*   To add responsibilities to individual objects dynamically and transparently, without affecting other objects.
*   For responsibilities that can be withdrawn.
*   When extension by subclassing is impractical due to a large number of independent extensions or when a class definition is hidden or otherwise unavailable for subclassing.
*   To avoid feature bloat in superclasses. Instead of a class having many optional features, you can decorate a core component with only the features you need.
*   Common use cases include adding logging, caching, validation, security checks, or transaction management to existing operations.

## 🌟 .NET Analogy
*   **`System.IO.Stream` subclasses**: `BufferedStream`, `CryptoStream`, `GZipStream`, and `DeflateStream` are classic examples. They wrap an existing `Stream` object and add functionalities like buffering, encryption/decryption, or compression/decompression, while still exposing the `Stream` interface.
    ```csharp
    // Basic file stream
    Stream fileStream = new FileStream("file.txt", FileMode.Open);
    // Decorate with buffering
    Stream bufferedStream = new BufferedStream(fileStream);
    // Decorate with compression
    Stream gzipStream = new GZipStream(bufferedStream, CompressionMode.Compress);
    // All streams (fileStream, bufferedStream, gzipStream) can be used via the Stream interface.
    ```
*   **ASP.NET Core Middleware Pipeline**: While not a direct object decorator, the concept is similar. Each piece of middleware "decorates" the request handling pipeline by adding behavior before or after calling the next middleware.
*   **`System.Net.Http.HttpMessageHandler` chain**: Custom message handlers can be chained together, where each handler can process the request/response and then delegate to an inner handler, effectively decorating the HTTP call.

## 🚀 Domain Scenario: 📨 Enhancing Notification Sending
Imagine we have a basic notification sending service (`EmailSender`) that implements `INotificationSender`. We want to add extra functionalities to this service, such as:
1.  **Logging**: Log details before and after a notification is sent.
2.  **Retry Mechanism**: Retry sending the notification if it fails the first time.

Instead of modifying `EmailSender` or creating subclasses for every combination of features, we use decorators.

### ✨ Key Components:
*   **`INotificationSender` (Component Interface)**:
    *   Defines the common interface for both the objects being decorated and the decorators themselves.
    *   Declares the operation `void Send(string to, string message)`.
*   **`EmailSender` (Concrete Component)**:
    *   The basic object that implements `INotificationSender`.
    *   Provides the core functionality of sending an email.
*   **Decorator (Abstract - often implicit or a base class, not explicitly shown here but understood conceptually)**:
    *   Conforms to the `INotificationSender` interface.
    *   Holds a reference to a wrapped `INotificationSender` object (the component it decorates).
*   **Concrete Decorators (`LoggingNotificationDecorator`, `RetryNotificationDecorator`)**:
    *   **`LoggingNotificationDecorator`**:
        *   Implements `INotificationSender`.
        *   Wraps another `INotificationSender` (passed via constructor).
        *   In its `Send` method, it adds logging behavior (prints to console before and after) around the call to the wrapped object's `Send` method.
    *   **`RetryNotificationDecorator`**:
        *   Implements `INotificationSender`.
        *   Wraps another `INotificationSender`.
        *   In its `Send` method, it attempts to call the wrapped object's `Send` method. If an exception occurs, it catches it, logs a retry attempt, and calls `Send` again (a simple one-time retry).
*   **`Runner` (Client)**:
    *   Creates a concrete component (`EmailSender`).
    *   Dynamically wraps it with one or more decorators (e.g., `RetryNotificationDecorator` then `LoggingNotificationDecorator`).
    *   The client interacts with the outermost decorator using the `INotificationSender` interface, unaware of the layers of decoration.

### ⚙️ How it Works:
1.  The client (`Runner`) starts by creating a base component instance, e.g., `new EmailSender()`.
2.  This base component is then "decorated" by wrapping it with a decorator instance. For example:
    `INotificationSender sender = new EmailSender();`
    `sender = new RetryNotificationDecorator(sender);` // sender now has retry capability
    `sender = new LoggingNotificationDecorator(sender);` // sender now also has logging, around the retry
3.  When the client calls `sender.Send(...)` on the outermost decorator (`LoggingNotificationDecorator` in this case):
    *   The `LoggingNotificationDecorator` executes its pre-send logic (e.g., logs "Sending...").
    *   It then calls `Send()` on its wrapped object, which is the `RetryNotificationDecorator`.
    *   The `RetryNotificationDecorator` executes its logic. It calls `Send()` on *its* wrapped object (the `EmailSender`).
        *   If `EmailSender.Send()` succeeds, the `RetryNotificationDecorator`'s job is done.
        *   If `EmailSender.Send()` fails (throws an exception), the `RetryNotificationDecorator` catches it, logs, and tries `EmailSender.Send()` again.
    *   Control returns to `LoggingNotificationDecorator`, which executes its post-send logic (e.g., logs "Sent.").
4.  The client remains unaware of the specific decorators and interacts with the decorated object through the common `INotificationSender` interface.

Decorators allow for flexible and composable extension of object behavior at runtime, adhering to the Open/Closed Principle (classes are open for extension but closed for modification).