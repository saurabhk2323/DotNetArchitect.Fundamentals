# Flyweight Design Pattern 🍃

## 📜 Purpose
The **Flyweight** pattern is used to minimize memory usage or computational expenses by sharing as much data as possible with other similar objects. It is a way to use objects in large numbers when a simple repeated representation would use an unacceptable amount of memory. Often, some parts of the object state can be shared, and it's common to hold them in external data structures and pass them to the flyweight objects temporarily when they are used.

The pattern separates an object's state into:
*   **Intrinsic State**: Data that is shared among many objects (e.g., a character glyph in a text editor, a product category). This state is stored in the flyweight object.
*   **Extrinsic State**: Data that is unique to each instance and cannot be shared (e.g., the position of a character on a page, the specific product name and price). This state is passed to the flyweight's methods by the client.

## 🤔 When to Use
*   When an application uses a large number of objects.
*   Storage costs are high because of the sheer quantity of objects.
*   Most object state can be made extrinsic (passed to methods rather than stored in the object).
*   Many groups of objects may be replaced by relatively few shared objects once extrinsic state is removed.
*   The application doesn't depend on object identity. Since flyweight objects can be shared, identity comparisons will return true for conceptually distinct objects if they are represented by the same flyweight.

## 🌟 .NET Analogy
*   **`System.String` Interning**: When you have multiple string literals with the same value in your code, the .NET runtime often stores only one copy of that string in memory (string interning pool). Subsequent string literals with the same value will reference this single instance. This is a form of flyweight where the string's character data is the shared intrinsic state.
*   **`System.Drawing.Brush` and `System.Drawing.Pen` objects**: In GDI+, frequently used brushes and pens (like `Brushes.Red` or `Pens.Black`) are often cached and reused rather than creating new GDI objects each time.
*   **`System.Reflection.Emit.OpCodes`**: Each IL opcode is represented by a static readonly field on the `OpCodes` class, ensuring only one instance per opcode.
*   **`System.DBNull.Value`**: A single, shared instance representing a database null.

## 🚀 Domain Scenario: 🛍️ Product Catalog Optimization
Consider an e-commerce application displaying thousands or millions of products. Each product might have unique properties like `ProductName` and `Price` (extrinsic state), but also shared properties like `Brand`, `Category`, and `Warranty` information (intrinsic state). Storing this shared information repeatedly for each product instance would consume a lot of memory.

The Flyweight pattern helps by creating shared `ProductFlyweight` objects for common combinations of Brand, Category, and Warranty. Each `OrderItem` (or Product display object) will then hold its unique data and a reference to a shared `ProductFlyweight` object.

### ✨ Key Components:
*   **`ProductFlyweight` (Flyweight)**:
    *   Stores the intrinsic state that is shared: `Brand`, `Category`, `Warranty`.
    *   The constructor takes these shared properties.
    *   Has a method `Display(string name, decimal price)` that takes extrinsic state (product name, price) as parameters to display the full product information.
*   **`FlyweightFactory` (Flyweight Factory)**:
    *   Creates and manages flyweight objects.
    *   Maintains a pool (e.g., a `Dictionary`) of existing flyweights.
    *   `GetFlyweight(string brand, string category, string warranty)`:
        *   Checks if a flyweight with the given intrinsic state already exists in the pool.
        *   If yes, returns the existing instance.
        *   If no, creates a new `ProductFlyweight`, adds it to the pool, and then returns it.
        *   This ensures that flyweights with the same intrinsic state are shared.
*   **`OrderItem` (Client/UnsharedConcreteFlyweight Context)**:
    *   Represents an individual order item or product entry.
    *   Stores the extrinsic state: `ProductName`, `Price`.
    *   Holds a reference to a `ProductFlyweight` object, which contains the shared intrinsic state.
    *   Its `PrintDetails()` method calls the `Display()` method on its `ProductFlyweight`, passing its extrinsic state.
*   **`Runner` (Client)**:
    *   Uses the `FlyweightFactory` to get `ProductFlyweight` objects.
    *   Creates `OrderItem` instances, providing them with their unique extrinsic state and the shared `ProductFlyweight`.
    *   Calls `PrintDetails()` on `OrderItem` instances to display product information.

### ⚙️ How it Works:
1.  The client (`Runner`) needs to display several order items.
2.  For each item, it first requests a `ProductFlyweight` from the `FlyweightFactory` based on the item's shared properties (brand, category, warranty).
    *   The factory generates a unique key from these shared properties.
    *   If a flyweight for this key already exists in its cache, it returns the cached instance.
    *   Otherwise, it creates a new `ProductFlyweight` with these shared properties, caches it, and returns it.
3.  The client then creates an `OrderItem` instance, passing the unique properties (name, price) and the obtained (possibly shared) `ProductFlyweight`.
4.  When `orderItem.PrintDetails()` is called:
    *   The `OrderItem` invokes the `Display()` method on its `ProductFlyweight` instance.
    *   It passes its extrinsic state (name, price) to this `Display()` method.
    *   The `ProductFlyweight.Display()` method then uses both its intrinsic state (brand, category, warranty) and the passed extrinsic state to show the complete product details.

This way, if multiple `OrderItem`s share the same brand, category, and warranty (e.g., many "MacBook Air" items from "Apple", "Laptop" category, with "1 Year" warranty), they will all reference the *same* `ProductFlyweight` object, significantly reducing memory consumption compared to storing this information in each `OrderItem`.

The distinction between intrinsic (shared, stored in flyweight) and extrinsic (unique, passed to flyweight methods) state is crucial for the Flyweight pattern.