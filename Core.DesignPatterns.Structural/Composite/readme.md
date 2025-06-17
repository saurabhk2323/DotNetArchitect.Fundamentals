📘 Purpose:
"Treat individual objects and compositions of objects uniformly."

You can use the same interface to operate on a single object or a group of objects, recursively.

🧠 When to Use:
Use-Case									Example
Represent part-whole hierarchies			Orders → OrderItems
Apply operations recursively on groups		Batch Notifications
Uniform treatment of leaf and branch		Component.Render() on UI controls

📚 Real-World Analogies:
File system (File & Folder both support GetSize())

HTML DOM (Divs inside Divs)

UI controls (Control → Panel, Button, etc.)

🛠️ Domain Scenario: Orders & OrderItems
We model:

OrderItem → Leaf

OrderGroup → Composite (can contain OrderItem or other OrderGroup)

✅ Step 1: Define the Component Interface
IOrderComponent

✅ Step 2: Leaf Class → OrderItem

✅ Step 3: Composite Class → OrderGroup

🎯 Interview-Level Explanation
“The Composite pattern helped me model an order as a recursive structure. Whether it’s a single item or a group of items, I can treat them the same using the IOrderComponent interface. This pattern simplifies traversal and calculations over tree structures, and reduces branching in code logic.”