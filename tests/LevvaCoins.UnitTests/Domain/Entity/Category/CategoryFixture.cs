using DomainEntity = LevvaCoins.Domain.Entities;
namespace LevvaCoins.UnitTests.Domain.Entity.Category;
public class CategoryFixture
{
    public DomainEntity.Category GetValidCategory()
    {
        return new(
                "Description test"
            );
    }
}

[CollectionDefinition(nameof(CategoryFixture))]
public class CategoryTestFixtureCollection : ICollectionFixture<CategoryFixture>
{
}