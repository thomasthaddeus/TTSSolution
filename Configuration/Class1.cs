// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="Thaddeus Thomas">
//   Date: 2023-03-31
// </copyright>
// <summary>
//   The app settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Configuration
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// The app settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// The _configuration.
        /// </summary>
        private readonly IConfigurationRoot _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        /// <param name="configurationFilePath">
        /// The configuration file path.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        public AppSettings(string configurationFilePath)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(basePath: Path.GetDirectoryName(path: configurationFilePath) ?? throw new InvalidOperationException())
                .AddJsonFile(path: Path.GetFileName(path: configurationFilePath))
                .Build();
        }

        /// <summary>
        /// The get cognitive services subscription key.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
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