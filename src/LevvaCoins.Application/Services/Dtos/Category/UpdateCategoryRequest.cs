using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.Services.Dtos.Category;
public class UpdateCategoryRequest
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public UpdateCategoryRequest(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
}
