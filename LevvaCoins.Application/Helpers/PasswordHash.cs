using System.Security.Cryptography;
using System.Text;

namespace LevvaCoins.Application.Helpers
{
    public static class PasswordHash
    {
        public static string Generate(string value)
        {
            var hashValue = HashGenerate(value);

            return Convert.ToBase64String(hashValue);
        }

        public static bool Verify(string value, string sentHashValue)
        {
            var hashValue = HashGenerate(value);

            byte[] sentHash = Convert.FromBase64String(sentHashValue);

            var isSame = sentHash.SequenceEqual(hashValue);

            return isSame;
        }

        private static byte[] HashGenerate(string value)
        {
            var valueByte = Encoding.UTF8.GetBytes(value);
            return  SHA256.HashData(valueByte);
        }
    }
}
