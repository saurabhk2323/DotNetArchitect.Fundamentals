# Proxy Design Pattern 🛡️

## 📜 Purpose
The **Proxy** pattern provides a surrogate or placeholder for another object (the "real subject") to control access to it. This control can be used for various reasons, such as lazy initialization (virtual proxy), access control (protection proxy), logging requests (logging proxy), or caching results (caching proxy). The proxy implements the same interface as the real subject, so the client doesn't know it's dealing with a proxy.

## 🤔 When to Use
*   **Virtual Proxy**: When you want to delay the creation and initialization of a resource-intensive object until it's actually needed (lazy loading). For example, loading high-resolution images only when they become visible.
*   **Protection Proxy**: When you need to control access to an object based on permissions or other criteria. For example, different users might have different access rights to certain methods of an object.
*   **Remote Proxy**: To represent an object that resides in a different address space (e.g., on a remote server). The proxy handles the communication details, making the remote object appear local to the client. (e.g., WCF client proxies).
*   **Logging Proxy**: To log requests and responses when interacting with an object, for auditing or debugging purposes.
*   **Caching Proxy**: To cache the results of expensive operations and serve them from the cache for subsequent identical requests, improving performance.
*   **Smart Reference**: To perform additional actions when an object is accessed, such as reference counting or loading a persistent object into memory.

## 🌟 .NET Analogy
*   **`System.Lazy<T>`**: While not a full proxy object in the traditional sense, `Lazy<T>` provides a mechanism for lazy initialization, which is a common use case for a virtual proxy. The value is created only when `Lazy<T>.Value` is first accessed.
*   **Entity Framework Core Lazy Loading Proxies**: EF Core can create proxy classes for your entities that automatically load related data from the database when navigation properties are accessed for the first time.
*   **WCF Client Proxies (e.g., `ClientBase<TChannel>`)**: When you add a service reference for a WCF service, a client proxy class is generated. This proxy implements the service contract (interface) and handles the underlying communication (serialization, network calls) to the remote service, making it appear as if you're calling a local object.
*   **`System.Runtime.Remoting.Proxies.RealProxy` (older .NET Remoting)**: A base class for creating custom proxies to intercept method calls.
*   **Castle DynamicProxy or other AOP Frameworks**: These libraries allow dynamic creation of proxies at runtime to add cross-cutting concerns (like logging, caching, transaction management) to objects without modifying their code.

## 🚀 Domain Scenario: 💵 Order Cache Proxy
In this example, we have an `OrderService` that fetches order details, presumably from a database (which can be a slow operation). To improve performance for frequently accessed orders, we introduce a `CachedOrderProxy`. This proxy will cache orders after they are fetched for the first time and serve subsequent requests for the same order from the cache.

### ✨ Key Components:
*   **`IOrderService` (Subject Interface)**:
    *   Defines the common interface for both the real service and the proxy.
    *   Declares the operation `Order GetOrder(int orderId)`.
*   **`OrderService` (Real Subject)**:
    *   The actual class that performs the work, in this case, fetching order data.
    *   Its `GetOrder(int orderId)` method simulates a database call and returns an `Order` object.
*   **`CachedOrderProxy` (Proxy)**:
    *   Implements the `IOrderService` interface, so it can be used wherever an `IOrderService` is expected.
    *   Holds a reference to an instance of the real `OrderService` (`_realOrderService`).
    *   Maintains an internal cache (e.g., a `Dictionary<int, Order> _cache`) to store previously fetched orders.
    *   In its `GetOrder(int orderId)` method:
        *   It first checks if the requested order ID exists in the cache.
        *   If found, it returns the order from the cache (logging "Returned from cache.").
        *   If not found, it calls `_realOrderService.GetOrder(orderId)` to fetch the order from the real service (simulating a DB call, logging "Fetching from DB...").
        *   It then stores the fetched order in its cache before returning it to the client.
*   **`Order`**:
    *   A simple class representing order data, defined in `Core.DesignPatterns.Shared.Models.Order`.
*   **`Runner` (Client)**:
    *   Creates an instance of the real `OrderService`.
    *   Creates an instance of `CachedOrderProxy`, injecting the real service into it.
    *   Interacts with the `CachedOrderProxy` (as an `IOrderService`) to get orders.
    *   Demonstrates that the first call to `GetOrder()` for a specific ID goes to the real service, while subsequent calls for the same ID are served from the proxy's cache.

### ⚙️ How it Works:
1.  The client (`Runner`) wants to fetch an order. It has a reference to `CachedOrderProxy` (which implements `IOrderService`).
2.  The client calls `cachedOrderProxy.GetOrder(orderId)`.
3.  The `CachedOrderProxy` checks its internal cache for an order with the given `orderId`.
    *   **Cache Hit**: If the order is found in the cache, the proxy returns the cached `Order` object immediately.
    *   **Cache Miss**: If the order is not in the cache, the proxy delegates the call to the `GetOrder(orderId)` method of the wrapped `_realOrderService` instance.
        *   The `_realOrderService` fetches the order (e.g., from a database).
        *   The proxy receives the order from the real service, stores it in its cache (for future requests), and then returns it to the client.
4.  The client is unaware whether the order came from the cache or the real service directly, as it interacts with both through the common `IOrderService` interface.

This Caching Proxy helps reduce redundant calls to the expensive `OrderService` (e.g., database lookups) by serving frequently accessed data from a faster in-memory cache, thereby improving application performance and reducing load on the underlying system.