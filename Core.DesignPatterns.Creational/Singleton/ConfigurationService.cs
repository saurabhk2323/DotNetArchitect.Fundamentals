using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DesignPatterns.Creational.Singleton
{
    public sealed class ConfigurationService
    {
        private static readonly Lazy<ConfigurationService> _instance = new(() => new ConfigurationService());

        public static ConfigurationService Instance => _instance.Value;

        private ConfigurationService() { }
        public string EnvironmentName { get; private set; } = "Development";
        public void SetEnvironmentName(string env) => EnvironmentName = env;
    }
}
