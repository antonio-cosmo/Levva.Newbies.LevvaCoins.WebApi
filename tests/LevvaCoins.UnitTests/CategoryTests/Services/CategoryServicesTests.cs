using AutoMapper;
using FluentAssertions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Application.Categories.Services;
using LevvaCoins.Domain.ValueObjects;
using MediatR;
using Moq;
using LevvaCoins.Application.Categories.Queries;
using LevvaCoins.Domain.AppExceptions;

namespace LevvaCoins.Application.Tests.CategoryTest.Services
{
    public class CategoryServicesTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly IMapper _mapper;
        private readonly CategoryServices _categoryServices;
        public CategoryServicesTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapper = Mapper.Create();
            _categoryServices = new CategoryServices(_mediatorMock.Object, _mapper);
        }
        [Fact(DisplayName = "Should valid CreateCategoryDto return saved  CategoryDto")]
        public async Task ValidCreateCategoryDto_ReturnSavedCategoryDto()
        {
            //Arrange
            var description = new Description("Test category");
            var category = new Category(description);
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Description = category.Description.Text
            };

            var createCategoryDto = new CreateCategoryDto { Description = "Test category" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<SaveCategoryCommand>(), CancellationToken.None))
                .ReturnsAsync(category);

            //Act
            var result = await _categoryServices.SaveAsync(createCategoryDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(categoryDto);

            _mediatorMock.Verify(x => x.Send(It.IsAny<SaveCategoryCommand>(), CancellationToken.None), Times.Exactly(1));
        }

        [Fact(DisplayName = "Should valid id remove category")]
        public async Task ValidId_RemoveCategory()
        {
            //Arrange
            var categoryId = Guid.NewGuid();

            //Act
            await _categoryServices.RemoveAsync(categoryId);

            //Assert
            _mediatorMock.Verify(x => x.Send(It.IsAny<RemoveCategoryCommand>(), CancellationToken.None), Times.Exactly(1));
        }

        [Fact(DisplayName = "Should return all categories")]
        public async Task ReturnsAllCategories()
        {
            //Arrange
            var categories = new List<Category>() {
                new Category(new Description("category 01")),
                new Category(new Description("category 02")),
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCategoryQuery>(), CancellationToken.None)).ReturnsAsync(categories);

            //Act
            var result = await _categoryServices.GetAllAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(categories.Count);
        }

        [Fact(DisplayName = "Should id exists return category")]
        public async Task CategoryIdExists_ReturnCategory()
        {
            //Arrange
            var categoryId = Guid.NewGuid();

            var description = new Description("Test category");
            var existsCategory = new Category(description);

            var categoryDto = new CategoryDto
            {
                Id = existsCategory.Id,
                Description = existsCategory.Description.Text
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), CancellationToken.None)).ReturnsAsync(existsCategory);

            //Act
            var result = await _categoryServices.GetByIdAsync(categoryId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(categoryDto);
        }

        [Fact(DisplayName = "Should category not exists throw ModelNotFoundException")]
        public async Task CategoryNotExists_ThrowModelNotFoundException()
        {
            //Arrange
            var categoryId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), CancellationToken.None)).ReturnsAsync(null as Category);

            //Act
            Func<Task> service = () => _categoryServices.GetByIdAsync(categoryId);

            //Assert
            await service.Should().ThrowAsync<ModelNotFoundException>().WithMessage("Categoria não existe.");
        }
        [Fact(DisplayName = "Should valid request update category")]
        public async Task ValidIdAndDto_UpdateCategory()
        {
            var categoryId = Guid.NewGuid();
            var updateDto = new UpdateCategoryDto
            {
                Description = "Test",
            };

            await _categoryServices.UpdateAsync(categoryId, updateDto);

            _mediatorMock.Verify(x => x.Send(It.IsAny<UpdateCategoryCommand>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Should invalid request Dto throw NullReferenceException")]
        public async Task InvalidRequestDto_ThrowNullReferenceException()
        {
            var categoryId = Guid.NewGuid();
            var updateDto = new UpdateCategoryDto
            {
                Description = null,
            };

            Func<Task> service = () => _categoryServices.UpdateAsync(categoryId, updateDto);

            await service.Should().ThrowAsync<NullReferenceException>();
        }
    }
}
