# ✨ Design Patterns in C# ✨

Welcome! This project offers a comprehensive collection of common design patterns implemented in C#. Each pattern is demonstrated with practical examples and includes a detailed explanation of its purpose, use cases, and a corresponding `readme.md` file within its respective directory.

Our goal is to provide clear, concise, and runnable examples to help you understand and apply these patterns in your own C# projects.

## 🗺️ Navigating This Repository

Each design pattern is organized into one of three categories:

*   🏗️ **Creational Patterns**: Deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.
*   🧱 **Structural Patterns**: Ease the design by identifying a simple way to realize relationships between entities and composing objects to obtain new functionalities.
*   🧩 **Behavioral Patterns**: Identify common communication patterns between objects and how they assign responsibilities.

You can find each pattern within its categorical directory (e.g., `Core.DesignPatterns.Creational/`). Inside each pattern's folder, you'll typically find:
*   The C# source code implementing the pattern.
*   A dedicated `readme.md` file explaining the pattern in detail, including its purpose, when to use it, .NET analogies, and the specific domain scenario implemented.

## 📖 Design Patterns Covered

### 🏗️ Creational Design Patterns

These patterns focus on *object creation mechanisms*, providing ways to create objects while hiding the creation logic, rather than instantiating objects directly using the `new` operator. This gives your program more flexibility in deciding which objects need to be created for a given use case.

*   **[Abstract Factory](./Core.DesignPatterns.Creational/AbstractFactory/)** 🏭:
    *   *Summary*: Provides an interface for creating families of related objects (e.g., notification senders and formatters for Email vs. SMS) without specifying concrete classes.
    *   *Use when*: You need to ensure that products from one family are used together and are compatible.

*   **[Builder](./Core.DesignPatterns.Creational/Builder/)** 👷:
    *   *Summary*: Separates the construction of a complex object (e.g., an e-commerce `Order` with multiple optional parts) from its representation, allowing step-by-step construction.
    *   *Use when*: An object has many optional parameters or requires a multi-step construction process.

*   **[Factory Method](./Core.DesignPatterns.Creational/Factory/)** (Simple Factory Implementation) 🏭:
    *   *Summary*: Centralizes object creation logic (e.g., creating `INotificationSender` instances for Email or SMS) through a static factory method.
    *   *Use when*: You want to decouple client code from concrete classes and centralize instantiation logic.

*   **[Prototype](./Core.DesignPatterns.Creational/Prototype/)** 🐑:
    *   *Summary*: Creates new objects by copying an existing instance (e.g., cloning an `Order` object, including its nested `Product` list, via `ICloneable`).
    *   *Use when*: Creating an object is expensive or complex, and you already have a similar object that can be copied.

*   **[Singleton](./Core.DesignPatterns.Creational/Singleton/)** ☝️:
    *   *Summary*: Ensures a class (e.g., `ConfigurationService`) has only one instance and provides a global access point to it, often using `Lazy<T>` for thread-safe lazy initialization.
    *   *Use when*: Exactly one instance of a class is needed for managing shared resources or global state.

### 🧱 Structural Design Patterns

These patterns concern *class and object composition*. They use inheritance to compose interfaces and define ways to compose objects to obtain new functionalities.

*   **[Adapter](./Core.DesignPatterns.Structural/Adapter/)** 🔌:
    *   *Summary*: Converts an incompatible interface (e.g., `ExternalSmsService`) into a target interface (`INotificationSender`) expected by the client, allowing them to work together.
    *   *Use when*: You need to integrate existing classes with incompatible interfaces into your application.

*   **[Bridge](./Core.DesignPatterns.Structural/Bridge/)** 🌉:
    *   *Summary*: Decouples an abstraction (e.g., different types of `Notification`) from its implementation (e.g., `IMessageSender` for Email/SMS), allowing both to vary independently.
    *   *Use when*: You want to avoid a permanent binding between an abstraction and its implementation, or when both need to evolve separately.

*   **[Composite](./Core.DesignPatterns.Structural/Composite/)** 🌳:
    *   *Summary*: Composes objects into tree structures (e.g., an `OrderGroup` containing `OrderItem`s and other `OrderGroup`s) and lets clients treat individual objects and compositions uniformly via `IOrderComponent`.
    *   *Use when*: You want to represent part-whole hierarchies and allow uniform operations on individual and composite objects.

*   **[Decorator](./Core.DesignPatterns.Structural/Decorator/)** 🎁:
    *   *Summary*: Attaches additional responsibilities (e.g., logging, retry logic via `LoggingNotificationDecorator`, `RetryNotificationDecorator`) to an object (`INotificationSender`) dynamically.
    *   *Use when*: You want to add functionality to objects dynamically without affecting other objects or using subclassing.

*   **[Facade](./Core.DesignPatterns.Structural/Facade/)** 🏛️:
    *   *Summary*: Provides a unified, simplified interface (e.g., `OrderFacade` for placing an order) to a complex subsystem of classes (Inventory, Payment, Notification, Shipping services).
    *   *Use when*: You want to provide a simple interface to a complex subsystem or decouple clients from the subsystem's internal complexity.

*   **[Flyweight](./Core.DesignPatterns.Structural/Flyweight/)** 🍃:
    *   *Summary*: Minimizes memory use by sharing common, immutable state (e.g., `ProductFlyweight` for brand, category) among many objects (`OrderItem`), while unique state is extrinsic.
    *   *Use when*: An application uses a large number of objects with shareable state, and memory optimization is critical.

*   **[Proxy](./Core.DesignPatterns.Structural/Proxy/)** 🛡️:
    *   *Summary*: Provides a surrogate or placeholder (e.g., `CachedOrderProxy`) for another object (`OrderService`) to control access, often for caching, lazy loading, or security.
    *   *Use when*: You need to add a level of indirection to control access to an object.

### 🧩 Behavioral Design Patterns

These patterns are concerned with *algorithms and the assignment of responsibilities between objects*. They describe not just patterns of objects or classes but also patterns of communication between them.

*   **[Chain of Responsibility](./Core.DesignPatterns.Behavioral/ChainOfResponsibility/)** 🔗:
    *   *Summary*: Decouples sender and receiver by passing a request (e.g., `Order` validation) along a chain of handlers (`OrderValidator` subclasses like `StockValidator`, `CreditValidator`) until handled.
    *   *Use when*: Multiple objects can handle a request, and the handler is not known in advance, or you want to process requests through a pipeline.

*   **[Command](./Core.DesignPatterns.Behavioral/Command/)** 🎬:
    *   *Summary*: Encapsulates a request as an object (e.g., `OrderCommand`, `NotifyCommand`), allowing for parameterization, queuing (via `CommandQueueInvoker`), logging, or undo operations.
    *   *Use when*: You need to decouple operations from their invokers, queue operations, or support undo/redo.

*   **[Observer](./Core.DesignPatterns.Behavioral/Observer/)** 👀:
    *   *Summary*: Defines a one-to-many dependency where observers (`InventoryObserver`, `BillingObserver`) are automatically notified and updated when a subject (`OrderPlaceSubject`) changes state.
    *   *Use when*: Changes to one object require changes in others without tight coupling, common in event-driven systems.

*   **[State](./Core.DesignPatterns.Behavioral/State/)** 🎭:
    *   *Summary*: Allows an object to alter its behavior when its internal state changes (e.g., conceptual `Order` changing behavior based on `IOrderState` like `NewOrderState`, `ProcessedOrderState`). The object appears to change its class.
    *   *Use when*: An object's behavior depends on its state, and it must change behavior at runtime. *Note: This entry describes a conceptual implementation.*

*   **[Strategy](./Core.DesignPatterns.Behavioral/Strategy/)** 📜:
    *   *Summary*: Defines a family of algorithms (e.g., `EmailNotification`, `SmsNotification` implementing `INotificationStrategy`), encapsulates each, and makes them interchangeable within a context (`NotificationService`).
    *   *Use when*: You need to select an algorithm from a family at runtime without altering the client.

## 🚀 Running the Examples

This project includes a `Core.DesignPatterns.Driver` console application that can be used to execute the example code for each design pattern.

To run a specific design pattern's example:
1.  Open the `Core.DesignPatterns.Driver/Program.cs` file.
2.  In the `Main` method, you will find commented-out lines for executing each pattern's `Runner.Execute()` method.
3.  Uncomment the line corresponding to the design pattern you wish to run. For example, to run the **Factory Method** pattern:
    ```csharp
    // Console.WriteLine("Running Factory Method pattern:\n");
    // Core.DesignPatterns.Creational.Factory.Runner.Execute();
    ```
    would become:
    ```csharp
    Console.WriteLine("Running Factory Method pattern:\n");
    Core.DesignPatterns.Creational.Factory.Runner.Execute();
    ```
4.  Ensure only the desired pattern's runner is uncommented to avoid multiple outputs.
5.  Build and run the `Core.DesignPatterns.Driver` project. The output will be displayed in the console.

Each design pattern's implementation typically includes a `Runner.cs` file with an `Execute()` method that demonstrates its usage.

---

Happy Learning! 💡
