# State Design Pattern 🎭

## 📜 Purpose
The **State** pattern allows an object to alter its behavior when its internal state changes. The object will appear to change its class because its behavior is determined by its current state. This pattern encapsulates states into separate classes and delegates state-specific behavior to them.

## 🤔 When to Use
*   When an object's behavior depends on its state and it must change its behavior at runtime depending on that state.
*   When operations have large, multipart conditional statements that depend on the object's state. The State pattern moves each branch of the conditional into a separate class.
*   To manage objects that go through multiple stages or states with different behaviors, such as in order lifecycles, UI workflows, authentication states, or ticketing systems.
*   When you want to avoid complex `switch/case` or `if-else` chains for managing state transitions and behaviors.

## 🌟 .NET Analogy
*   **Workflow Engines (e.g., Windows Workflow Foundation (WF), Elsa Core, Azure Logic Apps)**: These systems manage processes that transition through various states, with each state having specific behaviors and transition rules.
*   **Game Development**: Game entities (characters, objects) often have different states (e.g., idle, running, attacking, defending) with distinct behaviors. State machines, often implemented using the State pattern, are common.
*   **UI State Machines**: Managing the state of UI components or application flows, where different user actions are permissible or have different outcomes based on the current state.
*   The internal workings of some connection objects (like `SqlConnection`) which might change behavior based on whether the connection is open, closed, or broken.

## 🚀 Domain Scenario: 🛒 Order Lifecycle (Conceptual)
This section describes a conceptual scenario for an e-commerce order lifecycle.
*Note: The C# code files for this specific implementation are not currently present in this directory. The following describes a typical structure for such a scenario using the State pattern.*

An order in an e-commerce system progresses through various states:
*   **New**: The order has been created but not yet processed.
*   **Processed**: Payment has been confirmed, and inventory allocated.
*   **Shipped**: The order has been dispatched.
*   **Delivered**: The order has reached the customer.
*   **Cancelled**: The order has been cancelled.

Each state dictates which operations are valid. For example, an order can be cancelled if it's `New` or `Processed`, but not typically if it's already `Delivered`. Similarly, an order can only be marked `Shipped` if it was previously `Processed`.

### ✨ Key Components (Conceptual):
*   **`Order` (Context)**:
    *   Maintains an instance of a ConcreteState subclass that defines the current state.
    *   Has a reference to the current state object (`_currentState`).
    *   Delegates state-specific requests to the current state object.
    *   Provides a method for ConcreteStates to change its current state (`SetState(IOrderState state)`).
*   **`IOrderState` (State Interface)**:
    *   Defines a common interface for all concrete states.
    *   Declares methods representing operations that can be performed on the order, e.g.:
        *   `Next(Order order)`: Transitions the order to the next logical state.
        *   `Cancel(Order order)`: Attempts to cancel the order.
        *   `PrintStatus()`: Prints the current status of the order.
*   **Concrete States (`NewOrderState`, `ProcessedOrderState`, `ShippedOrderState`, `DeliveredOrderState`, `CancelledOrderState`)**:
    *   Each class implements `IOrderState`.
    *   Implements behavior specific to a particular state of the `Order` (Context).
    *   May transition the Context to another state by calling `order.SetState(...)`. For example, `NewOrderState.Next()` might change the order's state to `ProcessedOrderState`.

### ⚙️ How it Works (Conceptual):
1.  The `Order` (Context) object starts in an initial state (e.g., `NewOrderState`).
2.  When an operation is requested on the `Order` (e.g., processing payment, shipping), the `Order` delegates this request to its current `IOrderState` object.
3.  The current `IOrderState` object handles the request. Its implementation of the operation will be specific to that state.
4.  As part of handling the request, a ConcreteState object might cause the `Order` to transition to a new state. For example, after successfully processing payment, the `ProcessedOrderState` might transition the `Order` to `ShippedOrderState` when a `Ship()` operation is called.
5.  The client interacts with the `Order` object, largely unaware of the specific state classes, but observes that the `Order`'s behavior changes as its internal state changes.

---
### 🚫 When NOT to Use State Pattern for Order Lifecycle (Considerations)
The classic object-oriented State pattern, as described above, is powerful for in-memory state management. However, for typical enterprise applications, especially with microservices or distributed systems, other approaches are often more suitable for managing long-lived entity states like an Order Lifecycle:

*   **If your order system is microservices-based, uses HTTP APIs, or message queues, and persists state in a database (which it almost always should for orders):**
    *   **Better to use**:
        *   A `Status` property/enum (e.g., `OrderStatus.Processing`) in your database entity.
        *   **Domain Services** or **Application Services** to validate state transitions (e.g., a service method `ShipOrder(orderId)` would check if the current status allows shipping before updating it).
        *   REST endpoints that represent actions (e.g., `POST /orders/{id}/ship`).
        *   Optionally, use declarative state machine libraries like **Stateless.NET** for defining and managing the state transition rules in a more structured way within your services, without necessarily creating separate OO state classes for each entity instance.

The OO State pattern is most effective when the state changes are frequent, complex, and primarily managed within a single object's lifecycle in memory, rather than across distributed services and persistent storage.