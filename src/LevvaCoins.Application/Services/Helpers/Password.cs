using System.Security.Cryptography;
using System.Text;

namespace LevvaCoins.Application.Services.Helpers;

public class PasswordHash
{
    public readonly string HashedValue;

    public PasswordHash(string password)
    {
        HashedValue = GenerateHash(password);
    }

    private static string GenerateHash(string password)
    {
        var passwordHash = HashData(password);
        return Convert.ToBase64String(passwordHash);
    }

    private static byte[] HashData(string data)
    {
        return SHA256.HashData(Encoding.UTF8.GetBytes(data));
    }
}