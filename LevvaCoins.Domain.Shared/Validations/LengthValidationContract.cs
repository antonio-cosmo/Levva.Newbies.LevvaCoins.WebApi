using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Shared.Validations
{
    public partial class ValidationRule
    {
        public ValidationRule HasGreaterThan(int value, double comparer, string key, string message)
        {
            if (value < comparer)
            {
                AddNotification(key, message);
            }

            return this;
        }
        public ValidationRule HasGreaterThan(decimal value, decimal comparer, string key, string message)
        {
            if (value < comparer)
            {
                AddNotification(key, message);
            }

            return this;
        }
        public ValidationRule HasGreaterThan(string? value, double comparer, string key, string message)
        {
            if (value is null) return this;

            if (value.Length < comparer)
            {
                AddNotification(key, message);
            }

            return this;
        }

        public ValidationRule HasLowerThan(int value, double comparer, string key, string message)
        {
            if (value > comparer)
            {
                AddNotification(key, message);
            }

            return this;
        }
        public ValidationRule HasLowerThan(decimal value, decimal comparer, string key, string message)
        {
            if (value > comparer)
            {
                AddNotification(key, message);
            }

            return this;
        }

        public ValidationRule HasLowerThan(string? value, double comparer, string key, string message)
        {
            if (value is null) return this;

            if (value.Length > comparer)
            {
                AddNotification(key, message);
            }

            return this;
        }
    }
}
