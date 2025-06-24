📘 Purpose:
To allow an object to change its behavior when its internal state changes, appearing as if it changed its class.

🧠 When to Use:
- When an object goes through multiple stages (states) with different behaviors.
- You want to avoid complex switch/case or if-else chains.
- Common in order lifecycles, UI workflows, auth states, or ticketing systems.

📚 .NET Analogy:
- HttpClientHandler pipeline changes per authentication state.
- Workflow engines (e.g., Elsa, Azure Logic Apps).
- Game engines / UI state machines.

🛠️ Domain Scenario: 🛒 Order Lifecycle
🚚 States:
New → Processed → Shipped → Delivered → Cancelled
Each state has valid operations, others should be rejected.

1️⃣ Define the State Interface
	IOrderState
		Next(Order order)
		Cancel(Order order)
		void PrintStatus()

2️⃣ Define Concrete States
	NewOrderState : IOrderState

🧾 Processed
	ProcessedOrderState 

🚚 Shipped
	ShippedOrderState 

📦 Delivered
	DeliveredOrderState 

❌ Cancelled
	CancelledOrderState 

🧾 Order Class (Context)
	Order

🚫 When NOT to Use State Pattern for Order Lifecycle
If your order system is microservices-based

Uses HTTP APIs or message queues

Persists state in database (which it always should)

👉 Then it’s better to use:

REST endpoints

Status enum in DB

Domain services to validate transitions

Optionally use state machines like Stateless.NET for managing transitions declaratively (but not OO-style State Pattern)