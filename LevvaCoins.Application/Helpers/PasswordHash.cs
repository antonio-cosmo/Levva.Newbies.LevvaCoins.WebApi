using System.Security.Cryptography;
using System.Text;

namespace LevvaCoins.Application.Helpers
{
    public static class PasswordHash
    {
        public static string Generate(string password)
        {
            var passwordhash = HashGenerate(password);

            return Convert.ToBase64String(passwordhash);
        }

        public static bool Verify(string sendPassword, string currentPassword)
        {
            var sendPassworddHash = HashGenerate(sendPassword);

            byte[] currentPasswordHash = Convert.FromBase64String(currentPassword);

            var isSame = currentPasswordHash.SequenceEqual(sendPassworddHash);

            return isSame;
        }

        private static byte[] HashGenerate(string password)
        {
            var passwordByte = Encoding.UTF8.GetBytes(password);
            return  SHA256.HashData(passwordByte);
        }
    }
}
