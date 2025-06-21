using Core.DesignPatterns;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Design Patterns");
        //Console.WriteLine("Running Factory Method pattern:\n");
        //Core.DesignPatterns.Creational.Factory.Runner.Execute();

        //Console.WriteLine("\nRunning Singleton pattern:\n");
        //Core.DesignPatterns.Creational.Singleton.Runner.Execute();

        //Console.WriteLine("\nRunning Abstract Factory pattern:\n");
        //Core.DesignPatterns.Creational.AbstractFactory.Runner.Execute();

        //Console.WriteLine("\nRunning Builder pattern:\n");
        //Core.DesignPatterns.Creational.Builder.Runner.Execute();

        //Console.WriteLine("\nRunning Prototype pattern:\n");
        //Core.DesignPatterns.Creational.Prototype.Runner.Execute();

        Console.WriteLine("\nRunning Adapter pattern:\n");
        Core.DesignPatterns.Structural.Adapter.Runner.Execute();

        Console.WriteLine("\nRunning Decorator pattern:\n");
        Core.DesignPatterns.Structural.Decorator.Runner.Execute();

        Console.WriteLine("\nRunning Proxy pattern:\n");
        Core.DesignPatterns.Structural.Proxy.Runner.Execute();

        Console.WriteLine("\nRunning Composite pattern:\n");
        Core.DesignPatterns.Structural.Composite.Runner.Execute();

        Console.WriteLine("\nRunning Facade pattern:\n");
        Core.DesignPatterns.Structural.Facade.Runner.Execute();

        Console.WriteLine("\nRunning Bridge pattern:\n");
        Core.DesignPatterns.Structural.Bridge.Runner.Execute();

        Console.WriteLine("\nRunning Flyweight pattern:\n");
        Core.DesignPatterns.Structural.Flyweight.Runner.Execute();
    }
}