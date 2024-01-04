using AgendaBlueApi.Models;
using AutoMapper;

namespace AgendaBlueApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AgendaItem, AgendaItemDto>().ReverseMap();
        }
    }
}
