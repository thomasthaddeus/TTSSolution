using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public class AppSettings
    {
        private readonly IConfigurationRoot _configuration;

        public AppSettings(string configurationFilePath)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(basePath: Path.GetDirectoryName(path: configurationFilePath))
                .AddJsonFile(path: Path.GetFileName(path: configurationFilePath))
                .Build();
        }

        public string GetCognitiveServicesSubscriptionKey()
        {
            return _configuration[key: "CognitiveServices:SubscriptionKey"];
        }

        public string GetCognitiveServicesRegion()
        {
            return _configuration[key: "CognitiveServices:Region"];
        }

        // Add more methods here to get other configuration settings as needed
    }
}