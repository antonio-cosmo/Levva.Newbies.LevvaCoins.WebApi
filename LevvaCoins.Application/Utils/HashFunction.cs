using System.Security.Cryptography;
using System.Text;

namespace LevvaCoins.Application.Utils
{
    public static class HashFunction
    {
        public static string Generate(string data)
        {
            var dataByte = Encoding.UTF8.GetBytes(data);
            var hashValue = SHA256.HashData(dataByte);

            return Convert.ToBase64String(hashValue);
        }

        public static bool Verify(string text, string sentHashValue)
        {
            var textByte = Encoding.UTF8.GetBytes(text);
            var newHashValue = SHA256.HashData(textByte);

            byte[] sentHash = Convert.FromBase64String(sentHashValue);

            var isSame = sentHash.SequenceEqual(newHashValue);

            return isSame;
        }
    }
}
