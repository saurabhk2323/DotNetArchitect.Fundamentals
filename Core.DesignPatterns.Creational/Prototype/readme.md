# Prototype Design Pattern

## 📜 Purpose

The **Prototype** pattern specifies the kinds of objects to create using a prototypical instance, and creates new objects by copying (cloning) this prototype. It allows you to produce new objects by copying an existing object, rather than creating them from scratch using a constructor.

This is useful when the cost of creating an object is more expensive or complex than copying an existing one.

## 🤔 When to Use

*   When the classes to instantiate are specified at runtime, for example, by dynamic loading.
*   To avoid building a class hierarchy of factories that parallels the class hierarchy of products (as in Abstract Factory).
*   When instances of a class can have one of only a few different combinations of state. It may be more convenient to install a corresponding number of prototypes and clone them rather than instantiating the class manually, each time with the appropriate state.
*   When creating an object is expensive (e.g., involves database access, network calls, or complex computations) and you already have a similar object that can be copied.
*   When you want to reduce the number of subclasses by varying the state of an object instead of its class.

## 🌟 .NET Analogy

*   **`System.ICloneable` interface**: This interface, with its `Clone()` method, is the direct .NET mechanism for implementing the Prototype pattern. Objects that implement `ICloneable` can provide a copy of themselves. It's important to note whether the clone is a shallow copy or a deep copy.
*   **`System.Object.MemberwiseClone()`**: This protected method creates a shallow copy of the current object. It can be used within a class's custom `Clone()` method implementation.
*   Many UI elements or game objects might be created by cloning a template or a pre-configured instance.

## 🚀 Domain Scenario: Cloning an E-commerce Order

In this example, we demonstrate the Prototype pattern by cloning an e-commerce `Order` object. Imagine you have an existing order, and you want to create a new order that is very similar to it, perhaps with only a few modifications (e.g., a different promo code or a slight change in products). Instead of constructing the new order from scratch, we can clone the existing one.

### ✨ Key Components:

*   **`Order` (Concrete Prototype)**:
    *   Defined in `Core.DesignPatterns.Shared.Models.Order`.
    *   Implements the `System.ICloneable` interface, providing a public `Clone()` method.
    *   The `Clone()` method in `Order` performs a **deep copy**. This means it not only copies the scalar properties (like `Id`, `IsGift`, `DiscountPercentage`) but also creates new instances for reference types, specifically the `Products` list. Each `Product` in the original order's list is also cloned.
*   **`Product` (Concrete Prototype)**:
    *   Defined in `Core.DesignPatterns.Shared.Models.Product`.
    *   Also implements `System.ICloneable`.
    *   Its `Clone()` method copies the product's `Id`, `Name`, and `Price`.
*   **`Runner` (Client)**:
    *   The `Runner.cs` in the `Core.DesignPatterns.Creational.Prototype` directory demonstrates the usage.
    *   It first creates an `originalOrder` object and populates it with data, including a list of products.
    *   It then calls `originalOrder.Clone()` to create a `clonedOrder`.
    *   The client can then modify the `clonedOrder` (e.g., change its `Id` or `PromoCode`) independently of the `originalOrder`.

### ⚙️ How it Works:

1.  An initial `Order` object (`originalOrder`) is created and configured. This object serves as the prototype.
2.  The client calls the `Clone()` method on this `originalOrder`.
3.  The `Order.Clone()` method:
    *   Creates a new `Order` instance.
    *   Copies the values of simple properties (Id, IsGift, DiscountPercentage, etc.) from the original to the new instance.
    *   Crucially, for the `Products` list, it iterates through each `Product` in the original list, calls `Clone()` on each `Product`, and adds the cloned `Product` to the new order's `Products` list. This ensures that the cloned order has its own list of product objects, not just a reference to the original list (deep copy).
4.  The `Product.Clone()` method similarly creates a new `Product` instance and copies its properties.
5.  The client receives a new `Order` object (`clonedOrder`) that is a complete, independent copy of the original. Changes to the `clonedOrder` (or its products) will not affect the `originalOrder`, and vice-versa.

This pattern is effective for creating new objects that are variations of existing ones, reducing the overhead of manual construction and ensuring that complex object structures are copied correctly. The distinction between shallow and deep copy is critical when implementing `Clone()`:
*   **Shallow Copy**: Copies value types field by field. For reference types, it copies the reference, so both original and clone point to the same object.
*   **Deep Copy**: Copies value types field by field. For reference types, it creates new instances of the referenced objects and copies their values, recursively if needed. The `Order` example here performs a deep copy.
