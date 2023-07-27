using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.UseCases.Categories.Common
{
    public class CategoryModelOutput
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public CategoryModelOutput(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public static CategoryModelOutput FromDomain(Category category)
        {
            return new(
                    category.Id,
                    category.Description
                );
        }
        public static IEnumerable<CategoryModelOutput> FromDomain(IEnumerable<Category> categories)
        {
            return categories.Select(FromDomain);
        }
    }
}
