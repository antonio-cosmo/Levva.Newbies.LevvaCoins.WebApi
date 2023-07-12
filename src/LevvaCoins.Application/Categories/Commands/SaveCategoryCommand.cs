using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class SaveCategoryCommand : IRequest<Category>
    {
        public string Description { get; set; }

        public SaveCategoryCommand(string description)
        {
            Description = description;
        }
    }
}
