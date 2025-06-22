📘 Purpose:
Defines a one-to-many dependency between objects so that when one object changes state, all its dependents (observers) are notified and updated automatically.

🧠 When to Use:
When different parts of your system should react automatically to a change in one central object.

Perfect for event-driven systems.

Promotes loose coupling between publisher and subscribers.

📚 .NET Analogy:
INotifyPropertyChanged in WPF / MVVM

IObservable<T> and IObserver<T> in Reactive Extensions

Event handlers in C# (event + delegate)

🛠️ Domain Scenario: Notify Subsystems on Order Placement
Define the Observer Interface:
	IObserver --> Update(string evenData)

Define the Subject Interface:
	ISubject
		Attach(IObserver observer)
		Detach(IObserver observer)
		Notify(string eventData)

Concrete Subject - Order Service:
	OrderPlacedSubject  -> ISubject
		List<IObserver>
		Attach
		Detach
		Notify(string eventData)
			Update - each observer

Concrete Observers:
	InventoryObserver --> IObserver
	BillingObserver   --> IObserver
	NotificationObserver --> IObserver
