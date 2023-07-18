using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.UseCases.Categories.Common
{
    public class CategoryOutput
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public CategoryOutput(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public static CategoryOutput FromDomain(Category category)
        {
            return new(
                    category.Id,
                    category.Description.Text
                );
        }
        public static IEnumerable<CategoryOutput> FromDomain(IEnumerable<Category> categories)
        {
            return categories.Select(FromDomain);
        }
    }
}
