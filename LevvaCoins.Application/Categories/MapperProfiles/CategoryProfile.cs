using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Categories.MapperProfiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<SaveCategoryDto, SaveCategoryCommand>().ReverseMap();
            CreateMap<UpdateCategoryDto, UpdateCategoryCommand>().ReverseMap();
            CreateMap<SaveCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
