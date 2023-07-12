using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Exceptions;
public class EntityValidationException : Exception
{
    public EntityValidationException() : base()
    {
    }

    public EntityValidationException(string? message) : base(message)
    {
    }

    public EntityValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
