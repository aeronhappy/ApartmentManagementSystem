using AutoMapper;
using Ownership.Application.Response;
using Ownership.Domain.Entities;
using Property.Domain.Entities;

namespace Ownership.Infrastracture.MappingProfile
{

    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile()
        {
            CreateMap<Owner, OwnerResponse>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
