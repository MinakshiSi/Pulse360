using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

public class KeyVaultProvider
{
    private readonly SecretClient _client;

    public KeyVaultProvider(IConfiguration config)
    {
        var vaultUri = new Uri(config["KeyVault:Uri"]);
        _client = new SecretClient(vaultUri, new DefaultAzureCredential());
    }

    public async Task<string> GetSecretAsync(string name)
    {
        var secret = await _client.GetSecretAsync(name);
        return secret.Value.Value;
    }
}
