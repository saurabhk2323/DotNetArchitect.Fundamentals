# Adapter Design Pattern 🔌

## 📜 Purpose
The **Adapter** pattern (also known as Wrapper) converts the interface of a class into another interface that clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces. It acts as a bridge between two incompatible interfaces.

## 🤔 When to Use
*   When you want to use an existing class, but its interface does not match the one you need.
*   When you want to create a reusable class that cooperates with unrelated or unforeseen classes, that is, classes that don't necessarily have compatible interfaces.
*   When you need to use several existing subclasses, but it’s impractical to adapt their interface by subclassing every one. An object adapter can adapt the interface of its parent class.
*   When integrating with third-party libraries or legacy systems that have interfaces different from what your current application expects.
*   To make new code compatible with older systems or interfaces.

## 🌟 .NET Analogy
*   **`System.IO.StreamReader` and `System.IO.StreamWriter`**: These classes adapt a `System.IO.Stream` (which works with bytes) to provide text-based reading and writing capabilities (interfaces working with characters and strings).
*   **`System.Xml.XmlReader.Create(Stream)`**: Adapts a `Stream` to an `XmlReader` interface.
*   **P/Invoke (Platform Invocation Services)**: Allows managed C# code to call unmanaged functions in DLLs (e.g., Win32 API). This can be seen as a form of adapting unmanaged code to be callable from managed code.
*   **COM Interop**: Allows .NET objects to interact with COM objects, effectively adapting interfaces between these two different component models.

## 🚀 Domain Scenario: 📲 Integrating an External SMS Provider
Imagine our application uses an internal `INotificationSender` interface for sending notifications. We now want to integrate a third-party SMS service (`ExternalSmsService`) which has a different method signature for sending SMS messages. We need an adapter to make `ExternalSmsService` compatible with our `INotificationSender` interface.

### ✨ Key Components:
*   **`INotificationSender` (Target Interface)**:
    *   This is the interface our client application expects for sending notifications.
    *   It defines a method: `void Send(string to, string message)`.
*   **`ExternalSmsService` (Adaptee)**:
    *   This is the existing class (e.g., a third-party library) that we want to use, but its interface is incompatible with `INotificationSender`.
    *   It has a method: `void SendSmsToUser(string mobileNumber, string content)`. Note the different method name and parameter names.
*   **`SmsNotificationAdapter` (Adapter)**:
    *   Implements the `INotificationSender` (Target) interface.
    *   Wraps an instance of the `ExternalSmsService` (Adaptee). It usually takes an instance of the adaptee in its constructor.
    *   The `Send(string to, string message)` method of the adapter translates the call into a call to the adaptee's method: `_externalSmsService.SendSmsToUser(to, message)`. It maps the parameters appropriately.
*   **`Runner` (Client)**:
    *   The client code that wants to send a notification using the `INotificationSender` interface.
    *   It creates an instance of `SmsNotificationAdapter`, possibly injecting the `ExternalSmsService` into it.
    *   It then calls `notificationSender.Send(...)` without needing to know about the `ExternalSmsService` or its specific interface.

### ⚙️ How it Works:
1.  The client (`Runner`) is programmed to work with the `INotificationSender` interface.
2.  To use the `ExternalSmsService`, the client instantiates `SmsNotificationAdapter`, passing an instance of `ExternalSmsService` to its constructor.
3.  The client calls the `Send(to, message)` method on the `SmsNotificationAdapter` instance (which it sees as an `INotificationSender`).
4.  The `SmsNotificationAdapter`'s `Send` method, in turn, calls the `SendSmsToUser(mobileNumber, content)` method on the wrapped `ExternalSmsService` instance, translating the parameters as needed.
5.  This allows the client to use the `ExternalSmsService` through the `INotificationSender` interface, effectively "adapting" the external service to the interface the client expects.

The Adapter pattern allows us to integrate new services or legacy code into our existing systems without modifying the client code that expects a certain interface. It promotes loose coupling and reusability.

