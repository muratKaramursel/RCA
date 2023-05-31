using Microsoft.Extensions.Configuration;

namespace RCA.Core
{
    internal static class ConfigurationRootHelper
    {
        private static IConfigurationRoot _configurationRoot;
        private static readonly object _lockObject = new();

        private static IConfigurationBuilder GetConfigurationBuilder()
        {
            string environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrWhiteSpace(environmentVariable))
                environmentVariable = "Development";

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings." + environmentVariable + ".json", optional: false);

            return configurationBuilder;
        }
        public static IConfigurationRoot GetConfigurationRoot()
        {
            if (_configurationRoot == null)
                lock (_lockObject)
                    _configurationRoot ??= GetConfigurationBuilder().Build();
            return _configurationRoot;
        }
    }
}