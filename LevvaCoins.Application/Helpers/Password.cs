using System.Security.Cryptography;
using System.Text;

namespace LevvaCoins.Application.Helpers
{
    public class PasswordHash
    {
        public string Value { get; }
        public PasswordHash(string password)
        {
            Value = ToHash(password);
        }

        public bool IsSame(string expectedPassword)
        {
            return Value.SequenceEqual(expectedPassword);
        }

        private string ToHash(string password)
        {
            var passwordhash = HashGenerate(password);
            return Convert.ToBase64String(passwordhash);
        }

        private byte[] HashGenerate(string password)
        {
            var passwordByte = Encoding.UTF8.GetBytes(password);
            return SHA256.HashData(passwordByte);
        }
    }
}
