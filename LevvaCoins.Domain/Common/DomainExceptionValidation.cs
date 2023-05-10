using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Common
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string message): base(message) { }

        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(errorMessage);
            }
        }
    }
}
