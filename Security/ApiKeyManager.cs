using System;
using System.Collections.Generic;

namespace Security
{
    public class ApiKeyManager
    {
        private readonly Dictionary<string, DateTime> _apiKeys;

        public ApiKeyManager()
        {
            _apiKeys = new Dictionary<string, DateTime>();
        }

        public string GenerateApiKey()
        {
            var apiKey = Guid.NewGuid().ToString();
            _apiKeys[apiKey] = DateTime.UtcNow;

            return apiKey;
        }

        public bool IsValidApiKey(string apiKey)
        {
            if (_apiKeys.TryGetValue(apiKey, out var creationDate))
            {
                TimeSpan age = DateTime.UtcNow - creationDate;
                if (age < TimeSpan.FromDays(30)) // Assuming the API key is valid for 30 days
                {
                    return true;
                }
            }

            return false;
        }

        public void RevokeApiKey(string apiKey)
        {
            _apiKeys.Remove(apiKey);
        }
    }
}
