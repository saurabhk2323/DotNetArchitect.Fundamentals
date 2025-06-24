# Builder Design Pattern

## 📜 Purpose

The **Builder** pattern separates the construction of a complex object from its representation, allowing the same construction process to create various representations. It's designed to provide flexibility in object creation, especially when objects have many optional parameters or require a multi-step construction process.

Instead of having constructors with a long list of parameters (some of which might be null or default), the Builder pattern allows you to construct an object step-by-step and then retrieve the final object.

## 🤔 When to Use

*   When the algorithm for creating a complex object should be independent of the parts that make up the object and how they're assembled.
*   When the construction process must allow different representations for the object that's constructed (e.g., building a simple vs. a complex version of an object using the same process).
*   When an object has many optional parameters, and you want to avoid a "telescoping constructor" anti-pattern (multiple constructors with varying numbers of parameters).
*   When you want to ensure that an object is always in a valid state after construction, by controlling the construction process.
*   To create immutable objects by collecting all the information first and then creating the object in one go.

## 🌟 .NET Analogy

*   **`System.Text.StringBuilder`**: This is a classic example. You append strings, characters, or other data types step-by-step, and then call `ToString()` to get the final string. It's more efficient than concatenating strings repeatedly.
*   **`System.UriBuilder`**: Helps in constructing URIs by setting properties like Scheme, Host, Port, Path, Query, etc., and then retrieving the `Uri` object.
*   **Entity Framework Core Fluent API for Model Configuration**: When configuring entities and their relationships (e.g., `modelBuilder.Entity<Blog>().Property(b => b.Url).IsRequired();`), you are essentially using a builder (`ModelBuilder`, `EntityTypeBuilder`, `PropertyBuilder`) to define the structure of your database model.
*   **ASP.NET Core `WebApplicationBuilder` and `IHostBuilder`**: Used to configure and build web applications or generic hosts by setting up services, configuration, logging, etc., in a step-by-step manner before calling `Build()`.

## 🚀 Domain Scenario: E-commerce Order Construction

In this example, we're building an e-commerce `Order` object. An order can have many attributes:
*   A list of products.
*   A discount percentage.
*   A shipping type (e.g., Standard, Express).
*   A promotional code.
*   A payment method.
*   Whether it's a gift.

Creating such an `Order` object with a single constructor would be cumbersome due to the many optional fields. The Builder pattern simplifies this.

### ✨ Key Components:

*   **`Order` (Product)**:
    *   The complex object we want to create. It's defined in `Core.DesignPatterns.Shared.Models.Order`.
    *   It has properties like `Products` (list), `DiscountPercentage`, `ShippingType`, `PromoCode`, `PaymentMethod`, `IsGift`, and `TotalPrice`.
*   **`OrderBuilder` (Concrete Builder)**:
    *   Provides a fluent interface (methods that return `this`) to set the various attributes of the `Order`.
    *   Methods include:
        *   `AddProduct(Product product)`
        *   `AddProducts(IEnumerable<Product> products)`
        *   `WithDiscount(decimal discountPercentage)`
        *   `WithShippingType(string shippingType)`
        *   `ApplyPromoCode(string promoCode)`
        *   `PayWith(string paymentMethod)`
        *   `MarkAsGift()`
    *   Contains a private `_order` field which is an instance of `Order`.
    *   The `Build()` method returns the constructed `_order` object.
*   **`Runner` (Client/Director)**:
    *   The client code that uses the `OrderBuilder` to construct an `Order` object.
    *   It instantiates `OrderBuilder`, calls its various methods to configure the order, and finally calls `Build()` to get the `Order` instance.
    *   In this specific implementation, there isn't a separate `Director` class; the client (`Runner`) directs the construction process. A `Director` class could be introduced if there were predefined ways to construct different types of orders.

### ⚙️ How it Works:

1.  The client (`Runner.Execute()`) creates an instance of `OrderBuilder`.
2.  It then calls the builder's methods in a chained (fluent) manner to set the desired properties for the order. For example:
    ```csharp
    var order = new OrderBuilder()
        .AddProduct(new Product { ... })
        .MarkAsGift()
        .WithDiscount(10)
        .Build();
    ```
3.  Each configuration method in `OrderBuilder` modifies the internal `_order` instance and returns the builder itself, allowing for method chaining.
4.  Finally, the client calls the `Build()` method on the builder, which returns the fully constructed `Order` object.

This approach makes the client code more readable and simplifies the creation of `Order` objects, especially when many properties are optional or need to be set in a specific sequence. It also allows for easy extension by adding more methods to the `OrderBuilder` if new order attributes are introduced.
