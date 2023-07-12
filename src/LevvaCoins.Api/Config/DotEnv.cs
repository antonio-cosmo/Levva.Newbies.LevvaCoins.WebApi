using System.Linq;

namespace LevvaCoins.Api.Config
{
    public static class DotEnv
    {
        private const int ExpectedPartsCount = 2;

        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            var lines = ReadFile(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (IsValidLine(parts))
                {
                    SetEnvironmentVariable(parts[0], parts[1]);
                }
            }
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static bool IsValidLine(string[] parts)
        {
            return parts.Length == ExpectedPartsCount;
        }

        private static void SetEnvironmentVariable(string key, string value)
        {
            Environment.SetEnvironmentVariable(key, value);
        }
    }
}
