using System.IO;
using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public class AppSettings
    {
        private readonly IConfigurationRoot _configuration;

        public AppSettings(string configurationFilePath)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(configurationFilePath))
                .AddJsonFile(Path.GetFileName(configurationFilePath))
                .Build();
        }

        public string GetCognitiveServicesSubscriptionKey()
        {
            return _configuration["CognitiveServices:SubscriptionKey"];
        }

        public string GetCognitiveServicesRegion()
        {
            return _configuration["CognitiveServices:Region"];
        }
        // Add more methods here to get other configuration settings as needed
    }
}