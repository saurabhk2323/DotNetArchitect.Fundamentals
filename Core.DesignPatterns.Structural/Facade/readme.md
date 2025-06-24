# Facade Design Pattern

## 📜 Purpose

The **Facade** pattern provides a unified, simplified interface to a set of interfaces in a subsystem. It defines a higher-level interface that makes the subsystem easier to use by hiding its complexity. Clients interact with the facade rather than directly with the multiple, potentially complex, components of the subsystem.

## 🤔 When to Use

*   When you want to provide a simple interface to a complex subsystem. A facade can provide a limited but straightforward view for common tasks.
*   When you want to decouple a subsystem from its clients. The facade can be an intermediary, reducing the number of objects clients deal with and making the subsystem easier to use and modify.
*   When you want to layer your subsystems. Use a facade to define an entry point to each subsystem level. If subsystems are dependent, you can simplify their dependencies by making them communicate with each other through their facades only.
*   To wrap a poorly designed collection of APIs with a single, well-designed API.

## 🌟 .NET Analogy

*   **`System.IO.File` and `System.IO.Directory`**: These static classes provide a simple interface for common file and directory operations (e.g., `File.ReadAllText()`, `Directory.GetFiles()`). Internally, they handle more complex objects and system calls (like `FileStream`, permissions, etc.), but the client gets a much simpler API.
*   **`System.Net.Http.HttpClient`**: While `HttpClient` itself is a class you instantiate, its methods like `GetStringAsync()` or `PostAsJsonAsync()` provide a simplified way to perform HTTP requests, abstracting away many details of request/response handling, content negotiation, and connection management.
*   **ASP.NET Core `WebApplication.Run()`**: This simple method call starts a configured web server and begins listening for requests, hiding the complexities of server setup, request pipeline configuration, and service hosting.

## 🚀 Domain Scenario: E-commerce Order Placement

In this example, placing an order in an e-commerce system involves several steps and interactions with different backend services:
1.  Reserving the product in the **Inventory System**.
2.  Processing the payment via the **Payment System**.
3.  Sending an order confirmation via the **Notification System**.
4.  Arranging for dispatch via the **Shipping System**.

Instead of having the client code directly interact with each of these services, an `OrderFacade` simplifies this process into a single method call.

### ✨ Key Components:

*   **`OrderFacade` (Facade)**:
    *   Provides a single method: `PlaceOrder(Product product, string userEmail)`.
    *   This method internally coordinates the calls to the various subsystem components.
*   **Subsystem Classes**:
    *   **`InventoryService`**: Contains logic to reserve products (e.g., `Reserve(int productId)`).
    *   **`PaymentService`**: Contains logic to charge payments (e.g., `Charge(decimal amount)`).
    *   **`NotificationService`**: Contains logic to send notifications (e.g., `SendOrderConfirmation(string email)`).
    *   **`ShippingService`**: Contains logic to dispatch products (e.g., `Dispatch(int productId)`).
    *   *(In this example, these services are implemented as static classes with static methods for simplicity. In a real-world scenario, they would likely be regular classes, possibly interfaces with concrete implementations, managed by dependency injection.)*
*   **`Runner` (Client)**:
    *   The client code that wants to place an order.
    *   It instantiates `OrderFacade` and calls the `PlaceOrder` method, passing the product and user email.
    *   The client doesn't need to know about `InventoryService`, `PaymentService`, etc., or the sequence in which they must be called.

### ⚙️ How it Works:

1.  The client (`Runner.Execute()`) creates an instance of `OrderFacade`.
2.  The client calls the `PlaceOrder` method on the facade, providing the necessary product details and user information.
3.  The `OrderFacade.PlaceOrder` method then makes a sequence of calls to the appropriate methods in the subsystem classes:
    *   `InventoryService.Reserve(...)`
    *   `PaymentService.Charge(...)`
    *   `NotificationService.SendOrderConfirmation(...)`
    *   `ShippingService.Dispatch(...)`
4.  The client remains unaware of these internal interactions. From its perspective, placing an order is a single operation.

The Facade pattern simplifies the client's interaction with the complex underlying system. It promotes loose coupling between the client and the subsystem, as changes within the subsystem (e.g., how inventory is reserved) do not necessarily affect the client as long as the facade's interface remains stable.
