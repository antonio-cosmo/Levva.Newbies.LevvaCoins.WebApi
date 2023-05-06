using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.AppExceptions
{
    public class ModelAlreadyExistsException : Exception
    {
        public ModelAlreadyExistsException(string message = "Model already exists") : base(message) { }

    }
}
