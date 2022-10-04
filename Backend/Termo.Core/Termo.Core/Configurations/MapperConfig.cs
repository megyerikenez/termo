using AutoMapper;
using Termo.Core.Models.ToulousePieron;
using Termo.Data.Models;

namespace Termo.Core.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ToulousePieronDto, ToulousePieronTest>().ReverseMap();
        }
    }
}
