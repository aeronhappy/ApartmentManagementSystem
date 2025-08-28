using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastracture.MappingProfile
{

    public class TenantMappingProfile : Profile
    {
        public TenantMappingProfile()
        {
            CreateMap<Tenant, TenantResponse>()
                .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
            CreateMap<Tenant, TenantResponseWithoutLeaseAgreement>()
               .ForMember(o => o.Id, option => option.MapFrom(o => o.Id.Value));
        }
    }
}
