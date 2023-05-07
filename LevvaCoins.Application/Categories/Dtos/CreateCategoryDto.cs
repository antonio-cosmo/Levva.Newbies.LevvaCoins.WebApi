using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.Categories.Dtos
{
    public class CreateCategoryDto
    {
        string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                _description = value.ToLower();
            }
        }
    }
}
