# Observer Design Pattern 👀

## 📜 Purpose
The **Observer** pattern defines a one-to-many dependency between objects so that when one object (the "subject" or "observable") changes state, all its dependents (the "observers") are notified and updated automatically. This pattern promotes loose coupling between the subject and its observers.

## 🤔 When to Use
*   When a change to one object requires changing others, and you don't know how many objects need to be changed or what their types are.
*   When an object should be able to notify other objects without making assumptions about who these objects are. In other words, you want to decouple the objects.
*   In event-driven systems.
*   When you need to ensure that related objects remain synchronized, but you want to avoid tight coupling.
*   For implementing distributed event-handling systems.

## 🌟 .NET Analogy
*   **Events and Delegates in C#**: This is the most direct and common implementation of the Observer pattern in .NET. An event in a class acts as the subject, and methods (delegates) from other classes can subscribe (observe) that event.
    ```csharp
    public class Publisher {
        public event EventHandler SomethingHappened;
        public void DoSomething() {
            SomethingHappened?.Invoke(this, EventArgs.Empty);
        }
    }
    public class Subscriber {
        public void HandleEvent(object sender, EventArgs e) { /* ... */ }
    }
    // publisher.SomethingHappened += subscriber.HandleEvent;
    ```
*   **`System.ComponentModel.INotifyPropertyChanged`**: Used extensively in WPF, UWP, Xamarin.Forms (MVVM). When a property in a data model (subject) changes, it raises the `PropertyChanged` event, and UI elements (observers) bound to that property update themselves.
*   **`System.IObservable<T>` and `System.IObserver<T>` (Reactive Extensions - Rx.NET)**: These interfaces provide a more advanced and powerful implementation of the Observer pattern, allowing for complex event stream manipulation (filtering, composing, transforming).
*   **`System.Collections.Specialized.INotifyCollectionChanged`**: Used by observable collections (like `ObservableCollection<T>`) to notify listeners when the collection changes (items added, removed, replaced, etc.).

## 🚀 Domain Scenario: 🛒 Notifying Subsystems on Order Placement
In this example, when a new order is placed in an e-commerce system, several other subsystems need to be informed to perform their respective tasks:
1.  **Inventory System**: Needs to adjust stock levels.
2.  **Billing System**: Needs to generate an invoice.
3.  **Notification System**: Needs to send an order confirmation to the customer.

The `OrderPlaceSubject` acts as the subject. When an order is "placed" (simulated by its `Notify` method), it informs all registered observers.

### ✨ Key Components:
*   **`ISubject` (Subject Interface)**:
    *   Declares methods for managing observers: `Attach(IObserver observer)`, `Detach(IObserver observer)`, and `Notify(string eventData)`.
*   **`IObserver` (Observer Interface)**:
    *   Declares the `Update(string eventData)` method, which is called by the subject when its state changes.
*   **`OrderPlaceSubject` (Concrete Subject)**:
    *   Implements `ISubject`.
    *   Maintains a list of `IObserver` objects (`_observers`).
    *   `Attach()` adds an observer to the list.
    *   `Detach()` removes an observer from the list.
    *   `Notify(string eventData)` iterates through the list of observers and calls their `Update()` method, passing along event data (e.g., an order ID).
*   **Concrete Observers**:
    *   **`InventoryObserver`**: Implements `IObserver`. Its `Update()` method simulates adjusting inventory.
    *   **`BillingObserver`**: Implements `IObserver`. Its `Update()` method simulates generating an invoice.
    *   **`NotificationObserver`**: Implements `IObserver`. Its `Update()` method simulates sending a notification.
*   **`Runner` (Client)**:
    *   Creates an instance of `OrderPlaceSubject`.
    *   Creates instances of concrete observers (`InventoryObserver`, `BillingObserver`, `NotificationObserver`).
    *   Attaches these observers to the subject using `subject.Attach()`.
    *   Simulates an order placement by calling `subject.Notify("Order#123")`.
    *   Optionally demonstrates detaching observers.

### ⚙️ How it Works:
1.  The client creates a subject (`OrderPlaceSubject`) and several observer objects (`InventoryObserver`, `BillingObserver`, `NotificationObserver`).
2.  The client registers these observers with the subject using the `Attach()` method. The subject stores these observers in a list.
3.  When an event of interest occurs (e.g., an order is placed), the client (or the subject itself, if it manages its own state changes) calls the subject's `Notify()` method, passing relevant event data.
4.  The subject's `Notify()` method iterates through its list of registered observers and calls the `Update()` method on each one, providing the event data.
5.  Each observer's `Update()` method then performs its specific action based on the notification (e.g., Inventory adjusts stock, Billing generates an invoice).
6.  Observers can be dynamically attached or detached at runtime.

This pattern ensures that the `OrderPlaceSubject` doesn't need to know the concrete classes of its observers or what they do. It only knows that they implement `IObserver`. This promotes loose coupling and makes the system extensible—new observers can be added easily without changing the subject's code.
