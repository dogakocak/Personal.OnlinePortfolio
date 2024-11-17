namespace Personal.OnlinePortfolio.Server.Services
{
    public interface IKeyVaultService
    {
        Task<string> GetSecretAsync(string secretName);
    }
}
