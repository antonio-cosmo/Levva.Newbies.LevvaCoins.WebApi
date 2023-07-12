using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.MapperProfiles;

namespace LevvaCoins.Application.Tests
{
    public static class Mapper
    {
        public static IMapper Create()
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AddProfile(new DefaultMapper());
            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);

            return new AutoMapper.Mapper(mapperConfiguration);
        }
    }
}
