using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.Exceptions;
public class ModelAlreadyExistsException : Exception
{
    public ModelAlreadyExistsException() : base()
    {
    }
    public ModelAlreadyExistsException(string? message) : base(message)
    {
    }

    public ModelAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
