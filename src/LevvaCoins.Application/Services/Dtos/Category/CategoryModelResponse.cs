using DomainEntity = LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Services.Dtos.Category
{
    public class CategoryModelResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public CategoryModelResponse(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public static CategoryModelResponse FromDomain(DomainEntity.Category category)
        {
            return new(
                    category.Id,
                    category.Description
                );
        }
        public static IEnumerable<CategoryModelResponse> FromDomain(IEnumerable<DomainEntity.Category> categories)
        {
            return categories.Select(FromDomain);
        }
    }
}
