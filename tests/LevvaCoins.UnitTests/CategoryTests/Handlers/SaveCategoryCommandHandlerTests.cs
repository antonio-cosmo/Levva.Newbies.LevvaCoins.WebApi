using System;
using AutoMapper;
using FluentAssertions;
using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Application.Categories.Handlers;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.ValueObjects;
using Moq;

namespace LevvaCoins.Application.Tests.CategoryTests.Handlers
{
    public class SaveCategoryCommandHandlerTests
    {
        private readonly Mock<ICategoryRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly SaveCategoryCommandHandler _commandHandler;
        public SaveCategoryCommandHandlerTests()
        {
            _repositoryMock = new Mock<ICategoryRepository>();
            _mapper = Mapper.Create();
            _commandHandler = new SaveCategoryCommandHandler(_repositoryMock.Object, _mapper);
        }

        [Fact(DisplayName = "Should valid request return saved category")]
        public async Task ValidRequest_ReturnSavedCategory()
        {
            // Arrange
            var description = new Description("Test Category");
            var category = new Category(description);
            var command = new SaveCategoryCommand("Test Category");

            _repositoryMock.Setup(repo => repo.GetByDescriptionAsync(It.IsAny<string>()))
                .ReturnsAsync(null as Category);

            _repositoryMock.Setup(repo => repo.InsertAsync(It.IsAny<Category>()))
                .ReturnsAsync(category);

            // Act
            var result = await _commandHandler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(category);
            _repositoryMock.Verify(x => x.InsertAsync(It.IsAny<Category>()), Times.Exactly(1));
            _repositoryMock.Verify(x => x.GetByDescriptionAsync(It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact(DisplayName = "Should category already exists throw ModelAlreadyExistsException")]
        public async Task CategoryAlreadyExists_ThrowModelAlreadyExistsException()
        {
            //Arrange
            var description = new Description("Test Category");
            var existsCategory = new Category(description);

            var command = new SaveCategoryCommand(existsCategory.Description.Text);

            _repositoryMock.Setup(x => x.GetByDescriptionAsync(It.IsAny<string>())).ReturnsAsync(existsCategory);

            //Act
            Func<Task> handle = () => _commandHandler.Handle(command, CancellationToken.None);

            //Assert
            await handle.Should().ThrowAsync<ModelAlreadyExistsException>().WithMessage("Uma categoria com esse nome já existe.");
            _repositoryMock.Verify(x => x.GetByDescriptionAsync(It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact(DisplayName = "Should invalid category throw DomainValidationException")]
        public async Task InvalidCategory_ThrowsDomainValidationException()
        {
            //Arrange
            var description = new Description("Ab");
            var existingCategory = new Category(description);
            var command = new SaveCategoryCommand(existingCategory.Description.Text);

            _repositoryMock.Setup(x => x.GetByDescriptionAsync(It.IsAny<string>())).ReturnsAsync(null as Category);

            //Act
            Func<Task> handle = () => _commandHandler.Handle(command, CancellationToken.None);

            //Assert
            await handle.Should().ThrowAsync<DomainValidationException>().WithMessage("Entidade inválida.");
        }
    }
}
