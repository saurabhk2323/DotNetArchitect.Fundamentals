using Core.DesignPatterns.Creational;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Design Patterns");
        Console.WriteLine("Running Factory Method pattern:\n");
        Core.DesignPatterns.Creational.Factory.Runner.Execute();

        Console.WriteLine("\nRunning Singleton pattern:\n");
        Core.DesignPatterns.Creational.Singleton.Runner.Execute();
    }
}