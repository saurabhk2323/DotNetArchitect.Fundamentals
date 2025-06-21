🧠 What Is the Flyweight Pattern?
The Flyweight Pattern is used to minimize memory usage by sharing as much data as possible with similar objects.

🧭 When to Use It (Architect's View)
You have a very large number of objects at runtime (e.g., millions of Product entries).

Many of these objects share common, immutable data.

You want to externalize and reuse the shared state to optimize memory/performance.

🎯 Real Use Case 1: Product Catalog
Problem:
You have a web app that lists:

10,000+ Product items.

Each item has:

Name, Price (unique per item)

Brand, Category, Warranty Terms (shared by thousands of items)

👉 You don’t want to store the same brand/category string 10,000 times.

✅ Flyweight Solution:
Move shared fields (Brand, Category, Warranty) into a ProductFlyweight class.

Store them in a central factory that reuses existing flyweights.