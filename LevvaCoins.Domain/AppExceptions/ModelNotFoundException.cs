using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.AppExceptions
{
    public class ModelNotFoundException: Exception
    {
        public ModelNotFoundException(string message = "Model not found") : base(message) { }
    }
}
