using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Shared.Notifications;

namespace LevvaCoins.Domain.Shared.Validations
{
    public partial class ValidationRule : Notice<Notification>
    {
        public ValidationRule Requires()
        {
            return this;
        }
    }
}
