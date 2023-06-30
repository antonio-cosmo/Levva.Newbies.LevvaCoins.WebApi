using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Shared.Validations
{
    public partial class ValidationRule
    {
        public ValidationRule GuidIsNotEmpty(Guid val, string key, string message)
        {
            if (val == Guid.Empty)
            {
                AddNotification(key, message);
            }

            return this;
        }
    }
}
