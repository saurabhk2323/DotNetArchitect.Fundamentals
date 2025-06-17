✅ Proxy Pattern
📘 Purpose:
Provide a placeholder or surrogate for another object to control access, add security, or lazy load resources.

🧠 When to Use:
You need access control, caching, lazy initialization, or logging.

The real object is resource-intensive to create or you want to delay creation.

📚 .NET Analogy:
Lazy<T>

Entity Framework lazy-loading proxies

IHttpClientFactory internally builds a proxy to reuse clients

🛠️ Domain Scenario: Order Cache Proxy
Say OrderService gets data from Cosmos DB:
IOrderService --> GetOrder(id)

Basic Implementation
OrderService --> GetOrder(id)

✅ Now add a Caching Proxy:
CachedOrderProxy: IOrderService --> CachedOrderProxy(realService) --> GetOrder(id) --> first check the cache, if not found call the real service

“Proxy helps control access to costly resources. I implemented a caching proxy to reduce repeat DB calls for frequently accessed orders. This pattern is also useful for security, remote proxies, and lazy-loading.”