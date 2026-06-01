using System.Security.Cryptography;
using System.Text;

namespace ConstructionManagementSystem.Services;

public static class BuildTaskFlowPasswordHasher
{
    public static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }

    public static bool VerifyPassword(string password, string passwordHash)
    {
        var hash = HashPassword(password);
        return string.Equals(hash, passwordHash, StringComparison.OrdinalIgnoreCase);
    }
}
