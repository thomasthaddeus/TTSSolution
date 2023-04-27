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
            _apiKeys[key: apiKey] = DateTime.UtcNow;

            return apiKey;
        }

        public bool IsValidApiKey(string apiKey)
        {
            if (!_apiKeys.TryGetValue(key: apiKey, value: out var creationDate))
            {
                return false;
            }

            var age = DateTime.UtcNow - creationDate;
            return age < TimeSpan.FromDays(value: 30); // Assuming the API key is valid for 30 days
        }

        public void RevokeApiKey(string apiKey)
        {
            _apiKeys.Remove(key: apiKey);
            Console.WriteLine("Key has been revoked");
        }
    }
}