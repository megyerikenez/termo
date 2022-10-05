using AutoMapper;
using Termo.Core.Models.Bourdon;
using Termo.Core.Models.ChairLamp;
using Termo.Core.Models.ToulousePieron;
using Termo.Core.Models.User;
using Termo.Data.Models;

namespace Termo.Core.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ToulousePieronDto, ToulousePieronTest>().ReverseMap();

            CreateMap<ChairLampDto, ChairLampTest>().ReverseMap();
            CreateMap<ChairLampItemDto, ChairLampTestItem>().ReverseMap();

            CreateMap<BourdonDto, BourdonTest>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();

        }
    }
}
