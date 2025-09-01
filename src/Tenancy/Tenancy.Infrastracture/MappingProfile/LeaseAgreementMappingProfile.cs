using AutoMapper;
using Tenancy.Application.Response;
using Tenancy.Domain.Entities;

namespace Tenancy.Infrastracture.MappingProfile
{

    public class LeaseAgreementMappingProfile : Profile
    {
        public LeaseAgreementMappingProfile()
        {
            CreateMap<LeaseAgreement, LeaseAgreementResponse>()
                .ForMember(u => u.Id, option => option.MapFrom(u => u.Id.Value));

        }
    }
}
