📘 Purpose:
To pass a request along a chain of handlers. Each handler decides:
- To process the request,
- Or pass it to the next handler.

🧠 When to Use:
- You want to process an object through a series of filters/rules.
- You want to decouple request sender from the logic that handles it.
- When some rules apply conditionally.

📚 .NET Analogy:
- ASP.NET Core Middleware pipeline
- Authorization handlers (custom policies)
- FluentValidation chains

🛠️ Domain Scenario: 🛒 Order Validation Pipeline
👇 Business Rules:
When placing an order, we must validate:
- If the product is in stock
- If the customer has enough credit
- If the shipping address is valid

Each step is a handler, and forms a chain.

-------------------------------------------------------------------------------

1️⃣ Base Handler (Abstract)
Abstract OrderValidator
	protected OrderValidator _next_
	SetNext(OrderValidator next)
	abstract void Validate(Order order)

2️⃣ Concrete Validators
	🏪 Check Stock
		StockValidator : OrderValidator
	💳 Check Credit Limit
		CreditValidator: OrderValidator
	🏠 Check Shipping Address
		AddressValidator: OrderValidator

🎯 Interview Insight:
“We modeled our order validation process using Chain of Responsibility — 
each validator checked a single concern like stock, credit, or address, and passed control forward. 
This gave us clean separation of concerns and pluggable validation logic.”

🔁 Bonus: How It Maps to Middleware
csharp
Copy
Edit
public async Task Invoke(HttpContext context)
{
    // Do something
    await _next(context); // Pass to next
}
Same idea — each handler decides to:

Stop the chain

Or pass along