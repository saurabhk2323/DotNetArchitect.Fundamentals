📘 Purpose:
Encapsulate a request (operation) as an object, allowing you to:
- Queue it
- Log it
- Undo it
- Execute it later

Pass it as a parameter

🧠 When to Use:
1. You want to decouple sender and receiver of a command.

2. You need task queues, background jobs, or undo functionality.

3. You want to audit or persist operations.

4. Great for CQRS and background workers in .NET.

📚 .NET Analogy:
- IHostedService & background processing

- ICommand in WPF MVVM

- MediatR commands (Command/Handler pattern)

- Azure Durable Functions orchestrations

----------------------------------------
We’ll simulate:

✅ Placing an Order

✅ Sending a Notification

✅ Logging the operation

✅ Executing via Command Pattern (delayed queue style)

💼 Realistic Business Case
A user places an order.
This triggers:
- Order being created
- Notification being sent
- Action being logged

All of these are encapsulated as commands, queued, and executed later (e.g., by a background worker).

🎯 Final Class Overview
ICommand                    // Base Command Interface
OrderCommand                // Place an Order
NotifyCommand               // Send Notification
LogCommand                  // Log the Operation
CommandQueueInvoker         // Simulates a scheduler or task processor