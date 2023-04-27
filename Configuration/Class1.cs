// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="Thaddeus Thomas">
//   Date: 2023-03-31
// </copyright>
// <summary>
//   The app settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Azure.Identity;
using Azure.ResourceManager;

namespace Configuration
{
    using Microsoft.Extensions.Configuration;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The app settings.
    /// </summary>
    public abstract class AppSettings
    {
        /// <summary>
        /// The _configuration.
        /// </summary>
        public readonly IConfigurationRoot Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        /// <param name="configurationFilePath">
        /// The configuration file path.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        protected AppSettings(string configurationFilePath)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath: Path.GetDirectoryName(path: configurationFilePath) ?? throw new InvalidOperationException())
                .AddJsonFile(path: Path.GetFileName(path: configurationFilePath))
                .Build();
        }

        public static async Task<string?> CheckExists()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = await client.GetDefaultSubscriptionAsync();
            var resourceGroups = subscription.GetResourceGroups();
            const string resourceGroupName = "myRgName";

            bool exists = await resourceGroups.ExistsAsync(resourceGroupName);

            if (exists)
            {
                Console.WriteLine($"Resource Group {resourceGroupName} exists.");

                // We can get the resource group now that we know it exists.
                // This does introduce a small race condition where resource group could have been deleted between the check and the get.
                await resourceGroups.GetAsync(resourceGroupName);
            }
            else
            {
                Console.WriteLine($"Resource Group {resourceGroupName} does not exist.");
            }

            return null;
        }

        // Add more methods here to get other configuration settings as needed
    }
}