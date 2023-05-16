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

        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {

            var command = _mapper.Map<CreateCategoryCommand>(categoryDto);
            await _mediator.Send(command);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var command = new DeleteCategoryCommand(id);
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var query = new GetAllCategoryQuery();
            var categoryList = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<CategoryDto>>(categoryList);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var query = new GetCategoryByIdQuery(id);
            var category = await _mediator.Send(query);
            if(category is null) throw new ModelNotFoundException("Essa categoria não existe.");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            var command = new UpdateCategoryCommand(categoryDto.Description, id);
            
            await _mediator.Send(command);
        }
    }
}
