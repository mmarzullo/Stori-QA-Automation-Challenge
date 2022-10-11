using Microsoft.Extensions.Configuration;

namespace StoriTest.Shared
{
    public class ConfigurationReader
    {
        private static IConfigurationRoot? _configuration;
        private static readonly object _lock = new();

        private ConfigurationReader()
        {
        }

        public static IConfigurationRoot GetInstance()
        {
            if (_configuration == null)
            {
                lock (_lock)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile($"Config/TokenSecrets.json")
                        .AddJsonFile($"Config/Environment.json", optional: false);

                    _configuration = builder.Build();
                }
            }

            return _configuration;
        }
    }
}
