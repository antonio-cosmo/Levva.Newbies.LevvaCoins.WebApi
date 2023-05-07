using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.Common.Dtos
{
    public class ErrorResponse
    {
        public bool HasError { get; set; }
        public string? Message { get; set; }
    }
}
