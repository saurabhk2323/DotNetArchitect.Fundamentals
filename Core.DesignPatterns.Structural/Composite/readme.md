# Composite Design Pattern 🌳

## 📜 Purpose
The **Composite** pattern composes objects into tree structures to represent part-whole hierarchies. It lets clients treat individual objects (leaves) and compositions of objects (composites) uniformly through a shared interface. This means a client can perform an operation on an entire tree structure without needing to differentiate between individual leaf nodes and branch/composite nodes.

## 🤔 When to Use
*   When you want to represent part-whole hierarchies of objects (e.g., a file system with files and directories, a UI with simple controls and containers).
*   When you want clients to be able to treat individual objects and compositions of objects uniformly. The client code can operate on both leaves and composites through the same component interface.
*   To simplify client code, as it doesn't need to distinguish between simple and complex elements of a tree.
*   When you need to apply operations recursively on groups of objects.

## 🌟 .NET Analogy
*   **Windows Forms / WPF / UWP Controls**: UI elements like `Control` (in WinForms) or `UIElement` (in WPF/UWP) form a composite structure. A `Panel` or `Grid` can contain other controls (including other panels/grids or simple controls like `Button`, `TextBox`). Operations like rendering, hit-testing, or property inheritance often traverse this tree structure.
*   **XML and HTML DOM (Document Object Model)**: An XML or HTML document is a tree structure where elements can contain other elements or text nodes. APIs for manipulating these documents (like `System.Xml.XmlNode` or JavaScript DOM APIs) allow uniform interaction with nodes regardless of whether they are composites (elements with children) or leaves (text nodes, attributes).
*   **LINQ to XML (`XElement`, `XNode`)**: `XElement` can contain other `XNode` objects (which can be other `XElement`s, `XText`, `XComment`, etc.), forming a tree that can be queried and manipulated uniformly.
*   **File System Representations**: A directory can contain files or other directories. Operations like calculating total size or searching for a file can be applied uniformly to both.

## 🚀 Domain Scenario: 🛍️ E-Commerce Order Structure
In an e-commerce system, an order can consist of individual products (items) or bundles/groups of products (e.g., a "Gaming Combo Pack" that includes a keyboard and mouse, or a "Workstation Bundle" that includes a monitor and the gaming combo). We want to calculate the total price, apply discounts, or generate an invoice for the entire order, or parts of it, in a uniform way.

### ✨ Key Components:
*   **`IOrderComponent` (Component Interface)**:
    *   Defines the common interface for all objects in the composition, both leaves and composites.
    *   Declares operations applicable to all parts, such as:
        *   `string Name { get; }`
        *   `decimal GetTotalPrice()`
        *   `void ApplyDiscount(decimal percentage)`
        *   `string GenerateInvoice()`
*   **`OrderItem` (Leaf)**:
    *   Represents an individual product in the order.
    *   Implements `IOrderComponent`.
    *   `GetTotalPrice()` returns its own price.
    *   `ApplyDiscount()` applies a discount to its own price.
    *   `GenerateInvoice()` provides an invoice line for itself.
    *   It does not have child components.
*   **`OrderGroup` (Composite)**:
    *   Represents a bundle or a group of order components (which can be `OrderItem`s or other `OrderGroup`s).
    *   Implements `IOrderComponent`.
    *   Maintains a list of child components (`_components` of type `List<IOrderComponent>`).
    *   Provides methods to manage children (e.g., `AddComponent(IOrderComponent component)`).
    *   Implements operations defined in `IOrderComponent` by delegating to its children:
        *   `GetTotalPrice()`: Sums the total price of all its child components.
        *   `ApplyDiscount()`: Iterates over its children and calls `ApplyDiscount()` on each.
        *   `GenerateInvoice()`: Aggregates invoice lines from all its children, possibly adding a group header.
*   **`Runner` (Client)**:
    *   Interacts with the order structure through the `IOrderComponent` interface.
    *   Can create complex order structures by adding `OrderItem`s and `OrderGroup`s into other `OrderGroup`s.
    *   Can call operations like `GetTotalPrice()` or `ApplyDiscount()` on any component (leaf or composite) without needing to know its specific type.

### ⚙️ How it Works:
1.  The client (`Runner`) builds a tree structure representing the order. This can involve creating `OrderItem` (leaf) objects and `OrderGroup` (composite) objects. `OrderGroup`s can, in turn, contain other `OrderItem`s or `OrderGroup`s.
    *   Example: `fullOrder (OrderGroup)` contains `bundle (OrderGroup)` and `monitor (OrderItem)`. The `bundle` itself contains `keyboard (OrderItem)` and `mouse (OrderItem)`.
2.  The client can then treat any part of this structure uniformly. For instance, calling `fullOrder.GetTotalPrice()` will trigger a recursive calculation:
    *   `fullOrder` asks `bundle` and `monitor` for their total prices.
    *   `bundle` asks `keyboard` and `mouse` for their prices and sums them up.
    *   `monitor`, `keyboard`, and `mouse` (being leaves) return their individual prices.
3.  Similarly, `fullOrder.ApplyDiscount(10)` will recursively apply the discount to all components within the `fullOrder`, including those within nested `OrderGroup`s.
4.  The client code remains simple because it only needs to interact with the `IOrderComponent` interface, regardless of whether it's dealing with a single item or a complex group of items.

The Composite pattern simplifies the client's interaction with complex tree-like structures and promotes code reusability by allowing uniform treatment of individual objects and compositions.
