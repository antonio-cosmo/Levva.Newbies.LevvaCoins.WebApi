using FluentAssertions;
using LevvaCoins.Domain.Exceptions;
using DomainEntity = LevvaCoins.Domain.Entities;

namespace LevvaCoins.UnitTests.Domain.Entity.Category;

[Collection(nameof(CategoryFixture))]
public class CategoryTests
{
    private readonly CategoryFixture _categoryFixture;

    public CategoryTests(CategoryFixture categoryFixture)
    {
        _categoryFixture = categoryFixture;
    }

    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Catgeory")]
    public void Instantiate()
    {
        //Arrange
        var validCategory = _categoryFixture.GetValidCategory();

        //Act
        var category = new DomainEntity.Category(validCategory.Description);

        //Assert
        category.Should().NotBeNull();
        category.Description.Should().Be(validCategory.Description);
        category.Id.Should().NotBe(default(Guid));
        category.Id.Should().NotBe(Guid.Empty);
    }

    [Theory(DisplayName = nameof(InstantiateErrorWhenDescriptionIsEmpty))]
    [Trait("Domain", "Catgeory")]
    [InlineData(null)]
    [InlineData("   ")]
    public void InstantiateErrorWhenDescriptionIsEmpty(string? description)
    {
        //Arrange

        //Act
        Action action = () =>
        {
            var category = new DomainEntity.Category(description!);
        };
        //Assert
        action.Should().Throw<EntityValidationException>().WithMessage("Description should not be null");
    }
}
