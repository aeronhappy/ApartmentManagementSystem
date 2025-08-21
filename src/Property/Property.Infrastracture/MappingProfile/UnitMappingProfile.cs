using AutoMapper;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Infrastracture.MappingProfile
{

    public class UnitMappingProfile : Profile
    {
        public UnitMappingProfile()
        {
            CreateMap<Unit, UnitResponse>()
                .ForMember(u => u.Id, option => option.MapFrom(u => u.Id.Value));

        }
    }
}
