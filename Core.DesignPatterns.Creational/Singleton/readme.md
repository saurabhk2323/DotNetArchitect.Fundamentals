# Singleton Design Pattern

## 📜 Purpose

The **Singleton** pattern ensures that a class has only one instance and provides a global point of access to that instance. This is useful when exactly one object is needed to coordinate actions across the system, such as managing a shared resource like a database connection, a logger, or application configuration.

## 🤔 When to Use

*   When there must be exactly one instance of a class, and it must be accessible to clients from a well-known access point.
*   When the single instance should be extensible by subclassing, and clients should be able to use an extended instance without modifying their code (though this can make Singleton more complex).
*   For managing shared resources, like database connections, thread pools, or logging facilities.
*   For application-wide configuration settings.
*   When you need stricter control over global variables.

**Caution**: Overuse of Singletons can lead to tightly coupled code and make unit testing difficult, as they introduce global state. Consider alternatives like Dependency Injection for managing dependencies.

## 🌟 .NET Analogy

*   **`System.DBNull.Value`**: Represents a database null value. There's only one instance of `DBNull`.
*   **`System.Type.Missing`**: Used in COM interop, specifically with reflection, to represent a missing value.
*   While not strictly Singletons accessible via a static `Instance` property, concepts like `HttpContext.Current` (in older ASP.NET) or `Application.Current` (in WPF/UWP) provide a single, globally accessible context object for the current request or application scope.
*   Many logging frameworks provide a static logger instance or a static way to access a configured logger.

## 🚀 Domain Scenario: Application Configuration Service

In this example, we implement a `ConfigurationService` as a Singleton. This service is responsible for holding and providing access to application-wide configuration settings, such as the current environment name (e.g., "Development", "Production"). There should only be one instance of this configuration service throughout the application.

### ✨ Key Components:

*   **`ConfigurationService` (Singleton Class)**:
    *   `sealed class`: Prevents inheritance, which can sometimes complicate Singleton implementations if not handled carefully.
    *   `private static readonly Lazy<ConfigurationService> _instance = new(() => new ConfigurationService());`:
        *   This uses `System.Lazy<T>` to ensure thread-safe, lazy initialization. The `ConfigurationService` instance is created only when `_instance.Value` is first accessed.
        *   The `readonly` keyword ensures that the `Lazy<T>` instance itself cannot be reassigned after static initialization.
    *   `public static ConfigurationService Instance => _instance.Value;`:
        *   A public static property that provides the global access point to the single `ConfigurationService` instance.
    *   `private ConfigurationService() { }`:
        *   A private constructor prevents clients from creating new instances of `ConfigurationService` using the `new` operator.
    *   `EnvironmentName` property and `SetEnvironmentName` method:
        *   Example configuration data managed by the Singleton.
*   **`Runner` (Client)**:
    *   Demonstrates how to access the Singleton instance.
    *   It retrieves the instance twice (`config1` and `config2`) and shows that both variables point to the exact same object in memory using `ReferenceEquals(config1, config2)`.
    *   It also shows that changes made through one reference (`config1.SetEnvironmentName`) are reflected when accessing the data through the other reference (`config2.EnvironmentName`), because they are the same instance.

### ⚙️ How it Works:

1.  The first time any part of the application requests `ConfigurationService.Instance`, the `Lazy<T>` container (`_instance`) will execute the factory delegate `() => new ConfigurationService()`. This creates the single instance of `ConfigurationService` by calling its private constructor.
2.  The `Lazy<T>` container stores this instance.
3.  All subsequent calls to `ConfigurationService.Instance` will return the same stored instance without creating a new one.
4.  The `Lazy<T>` type handles thread safety, ensuring that even in a multi-threaded environment, only one instance is created.

This implementation is a robust and recommended way to implement Singletons in .NET due to its thread safety and lazy initialization features provided by `Lazy<T>`.
