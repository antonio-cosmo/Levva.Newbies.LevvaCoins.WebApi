using AutoMapper;
using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Application.Categories.Queries;
using LevvaCoins.Domain.AppExceptions;
using MediatR;

namespace LevvaCoins.Application.Categories.Services
{
    public class CategoryServices : ICategoryServices
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;
        public CategoryServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<CategoryDto> SaveAsync(CreateCategoryDto createCategoryDto)
        {
            var saveCommand = _mapper.Map<SaveCategoryCommand>(createCategoryDto);
            var category = await _mediator.Send(saveCommand);

            return _mapper.Map<CategoryDto>(category);
        }
        public async Task RemoveAsync(Guid id)
        {
            var removeCommand = new RemoveCategoryCommand(id);
            await _mediator.Send(removeCommand);
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var queryAll = new GetAllCategoryQuery();
            var categories = await _mediator.Send(queryAll);

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var queryById = new GetCategoryByIdQuery(id);
            var category = await _mediator.Send(queryById) ?? throw new ModelNotFoundException("Categoria não existe.");
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task UpdateAsync(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var updateCommand = GetInstanceUpdateCommand(id, updateCategoryDto);
            await _mediator.Send(updateCommand);
        }
        private static UpdateCategoryCommand GetInstanceUpdateCommand(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var description = updateCategoryDto.Description ?? throw new NullReferenceException(nameof(updateCategoryDto.Description));
            return new UpdateCategoryCommand(id, description);
        }
    }
}
