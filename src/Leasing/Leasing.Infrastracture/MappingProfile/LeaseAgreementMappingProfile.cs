using ApartmentManagementSystem.SharedKernel.Entitites;
using AutoMapper;
using Leasing.Application.Response;
using Leasing.Domain.Entities;

namespace Leasing.Infrastracture.MappingProfile
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
