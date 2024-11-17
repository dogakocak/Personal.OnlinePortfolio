using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Personal.OnlinePortfolio.Server.Services
{
    public class KeyVaultService : IKeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(string keyVaultUrl)
        {
            if(string.IsNullOrWhiteSpace(keyVaultUrl))
            {
                throw new ArgumentException("KeyVault URL is required", nameof(keyVaultUrl));
            }
            _secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

        }
        /// <summary>
        /// Belirtilen bir secret'ı Azure Key Vault'tan alır.
        /// </summary>
        /// <param name="secretName">Secret'ın adı</param>
        /// <returns>Secret'ın değeri</returns>
        public async Task<string> GetSecretAsync(string secretName)
        {
            if (string.IsNullOrWhiteSpace(secretName))
            {
                throw new ArgumentNullException(nameof(secretName), "Secret name cannot be null or empty.");
            }

            try
            {
                KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
                return secret.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving secret '{secretName}': {ex.Message}", ex);
            }
        }
    }
}
