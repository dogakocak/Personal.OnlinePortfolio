using Personal.OnlinePortfolio.Server.Services;

namespace Personal.OnlinePortfolio.Server.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddKeyVaultService(this IServiceCollection services, IConfiguration configuration)
        {
            var keyVaultUrl = configuration["KeyVault:VaultUrl"] ??
                throw new InvalidOperationException("KeyVault:VaultUrl configuration is missing.");

            services.AddSingleton<IKeyVaultService>(new KeyVaultService(keyVaultUrl));
        }
    }
}
