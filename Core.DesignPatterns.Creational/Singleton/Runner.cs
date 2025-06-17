using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Singleton
{
    public class Runner
    {
        public static void Execute()
        {
            var config1 = ConfigurationService.Instance;
            var config2 = ConfigurationService.Instance;

            Console.WriteLine($"Before making changes, Environment: {config2.EnvironmentName}");
            config1.SetEnvironmentName("Production");
            Console.WriteLine($"Both configs point to the same instance: {ReferenceEquals(config1, config2)}");
            Console.WriteLine($"Current Environment: {config2.EnvironmentName}");
        }
    }
}
