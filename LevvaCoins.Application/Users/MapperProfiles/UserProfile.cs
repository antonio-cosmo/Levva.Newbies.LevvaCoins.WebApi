using AutoMapper;
using LevvaCoins.Application.Users.Commands;
using LevvaCoins.Application.Users.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Users.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, SaveUserCommand>().ReverseMap();
            CreateMap<LoginResponseDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<SaveUserCommand, User>().ReverseMap();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
