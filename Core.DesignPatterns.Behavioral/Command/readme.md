# Command Design Pattern 🎬

## 📜 Purpose
The **Command** pattern encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations. It decouples the object that invokes the operation from the one that knows how to perform it.

## 🤔 When to Use
*   When you want to parameterize objects by an action to perform.
*   When you want to queue requests, schedule their execution, or execute them remotely.
*   When you want to support undoable operations. The command object can store all information required to revert its action.
*   For logging changes: a command object can hold all information about the operation, which can be easily logged.
*   To build systems with macro-recording capabilities or multi-level undo/redo.
*   In scenarios like task queues, background job processing, or wizard-like UIs where operations are performed sequentially.

## 🌟 .NET Analogy
*   **`System.Windows.Input.ICommand` in WPF/MVVM**: Used extensively to bind UI actions (like button clicks) to methods in a ViewModel, decoupling the View from the ViewModel logic.
*   **`System.Threading.Tasks.Task` and `Action`/`Func` delegates**: While not full command objects, they encapsulate units of work that can be passed around, queued (e.g., `ThreadPool.QueueUserWorkItem`), and executed.
*   **MediatR library**: Its request/handler pipeline (especially for commands and queries in CQRS) is a form of the Command pattern where requests are objects processed by dedicated handlers.
*   **ASP.NET Core `IHostedService` for background tasks**: Background tasks can be thought of as commands that are executed by the hosting environment.
*   **Azure Durable Functions**: Orchestrations in Durable Functions often involve scheduling and executing activity functions, which are like commands.

## 🚀 Domain Scenario: 🛒 Order Processing Queue
In this example, when a user places an order, several actions need to occur:
1.  The order itself needs to be processed by an **Order Service**.
2.  A **Notification Service** needs to inform the customer.
3.  An **Logging Service** needs to record the transaction.

Instead of the client directly calling these services, each action is encapsulated as a command object. These commands are then added to a queue and processed by an invoker, simulating a background task or a decoupled execution flow.

### ✨ Key Components:
*   **`ICommand` (Command Interface)**:
    *   Declares a single method, `Execute()`, which all concrete commands will implement.
*   **Concrete Commands**:
    *   **`OrderCommand`**: Encapsulates the action of placing an order. Its `Execute()` method simulates calling an order service.
    *   **`NotifyCommand`**: Encapsulates sending a notification. Its `Execute()` method simulates calling a notification service.
    *   **`LogCommand`**: Encapsulates logging an operation. Its `Execute()` method simulates writing to a log.
    *   Each concrete command holds the necessary parameters (e.g., order details, recipient info, log message) required to perform its action.
*   **`CommandQueueInvoker` (Invoker)**:
    *   Maintains a queue of `ICommand` objects (`_commands`).
    *   `AddCommand(ICommand command)`: Adds a command to the queue.
    *   `ProcessAll()`: Dequeues and executes each command in the queue by calling its `Execute()` method. This simulates a command processor or a task scheduler.
*   **Receivers (Implicit)**:
    *   The services that perform the actual work (Order Service, Notification Service, Logging Service) are implicitly represented by the `Console.WriteLine` statements within each command's `Execute()` method. In a real system, these would be separate classes that the command objects would interact with.
*   **`Runner` (Client)**:
    *   Creates instances of concrete commands, setting them up with the required data (e.g., order ID, customer email).
    *   Adds these commands to the `CommandQueueInvoker`.
    *   Triggers the processing of all queued commands by calling `invoker.ProcessAll()`.

### ⚙️ How it Works:
1.  The client (`Runner`) decides which operations need to be performed (place order, send notification, log action).
2.  For each operation, it creates a specific command object (e.g., `new OrderCommand(...)`, `new NotifyCommand(...)`).
3.  These command objects are added to the `CommandQueueInvoker`.
4.  At a later time, or in a different context (e.g., a background worker), the `invoker.ProcessAll()` method is called.
5.  The invoker iterates through its queue, taking one command at a time and calling its `Execute()` method.
6.  Each command then performs its encapsulated action (e.g., `OrderCommand` "processes" the order, `NotifyCommand` "sends" a notification).

This setup decouples the client (which initiates the requests) from the actual execution of these requests. The invoker doesn't need to know what specific commands it's executing, only that they implement `ICommand`. This allows for flexible addition of new commands, queuing, and deferred execution.