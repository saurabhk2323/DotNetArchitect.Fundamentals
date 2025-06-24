# Chain of Responsibility Design Pattern 🔗

## 📜 Purpose
The **Chain of Responsibility** pattern avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. It achieves this by creating a chain of handler objects. Each handler in the chain decides either to process the request or to pass it along the chain to the next handler.

## 🤔 When to Use
*   When you want to decouple the sender of a request from its receivers.
*   When more than one object can handle a request, and the handler isn't known beforehand but should be ascertained automatically.
*   When you want to issue a request to one of several objects without specifying the receiver explicitly.
*   When the set of objects that can handle a request should be specified dynamically.
*   Ideal for processing pipelines, event handling systems, or validation sequences where different rules or steps are applied conditionally.

## 🌟 .NET Analogy
*   **ASP.NET Core Middleware Pipeline**: Each piece of middleware in the pipeline can process an HTTP request and then either pass it to the next middleware or short-circuit the pipeline. This is a direct application of the Chain of Responsibility.
*   **Windows Communication Foundation (WCF) Behaviors and Message Inspectors**: These can intercept and process messages at various stages.
*   **`System.Windows.UIElement.RaiseEvent()` and Routed Events in WPF/UWP**: Events can "bubble" or "tunnel" through the element tree, allowing various elements in the hierarchy a chance to handle them.
*   **FluentValidation Chains**: Rule sets in FluentValidation can be chained and processed sequentially.

## 🚀 Domain Scenario: 🛒 Order Validation Pipeline
In this example, we model an e-commerce order validation process. When an order is placed, it must pass through several validation checks before it can be processed:
1.  **Stock Validation**: Check if the product quantity is available in stock.
2.  **Credit Validation**: Check if the order total is within the customer's credit limit.
3.  **Address Validation**: Check if a valid shipping address is provided.

Each validation step is a handler in the chain. If a validation fails at any point, the chain can be stopped.

### ✨ Key Components:
*   **`Order`**: A simple class representing the order data that needs to be validated (e.g., `OrderId`, `ProductName`, `ProductQuantity`, `TotalPrice`, `ShippingAddress`).
*   **`OrderValidator` (Abstract Handler)**:
    *   Declares an interface common to all concrete handlers.
    *   Holds a reference (`_next`) to the next handler in the chain.
    *   Provides a `SetNext(OrderValidator next)` method to build the chain.
    *   Declares an `abstract void Validate(Order order)` method that concrete handlers must implement.
*   **Concrete Validators (Concrete Handlers)**:
    *   **`StockValidator`**: Checks if the product quantity is available. If valid, passes the order to the next validator.
    *   **`CreditValidator`**: Checks if the order total exceeds a credit limit. If valid, passes the order to the next validator.
    *   **`AddressValidator`**: Checks if a shipping address is provided. If valid, and if there's a next validator, passes the order along.
*   **`Runner` (Client)**:
    *   Creates an `Order` instance.
    *   Builds the chain of responsibility by creating instances of concrete validators and linking them using `SetNext()`.
    *   Initiates the validation process by calling `Validate()` on the first handler in the chain (e.g., `stock.Validate(order)`).

### ⚙️ How it Works:
1.  The client (`Runner`) assembles the chain of validators: `StockValidator` -> `CreditValidator` -> `AddressValidator`.
2.  The client calls the `Validate()` method on the first handler (`StockValidator`) with an `Order` object.
3.  The `StockValidator` performs its check:
    *   If stock is insufficient, it might log an error and stop further processing (in this example, it prints a message and doesn't call `_next.Validate()`).
    *   If stock is available, it calls `_next.Validate(order)`, passing the request to the `CreditValidator`.
4.  The `CreditValidator` performs its check:
    *   If the credit limit is exceeded, it stops processing.
    *   If credit is okay, it calls `_next.Validate(order)`, passing the request to the `AddressValidator`.
5.  The `AddressValidator` performs its check:
    *   If the address is missing, it stops.
    *   If the address is valid, it would call `_next.Validate(order)` if there were more handlers. Since it's the last one, the chain concludes (successfully, if all prior checks passed).
6.  Each handler has the option to either handle the request (and possibly stop the chain) or pass it to the next handler. This allows for flexible and decoupled processing pipelines.

This pattern makes it easy to add new validation steps (new handlers) or reorder existing ones without modifying the individual handler classes significantly, only the chain construction logic in the client.