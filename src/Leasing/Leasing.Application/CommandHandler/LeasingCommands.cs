using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.Errors;
using AutoMapper;
using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.CommandHandler
{
    public class LeasingCommands : ILeasingCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeasingCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<LeaseAgreementResponse>> CreateLeasingAsync(Guid tenantId, Guid apartmentId, DateTime dateStart,double monthlyRent, LeaseTerm leaseTerm, CancellationToken cancellationToken)
        {
            Tenant? tenant = await _unitOfWork.Tenants.GetTenantByIdAsync(new TenantId(tenantId));

            if (tenant == null)
                return Result.Fail(new EntityNotFoundError($"No Tenant = {tenantId} found"));

            Apartment? apartment = await _unitOfWork.Apartments.GetApartmentByIdAsync(new ApartmentId(apartmentId));
            if (apartment == null)
                return Result.Fail(new EntityNotFoundError($"No Apartment = {apartmentId} found"));


            var leaseAgreement = LeaseAgreement.Create(new TenantId(tenantId),new ApartmentId(apartmentId),dateStart, leaseTerm,monthlyRent);
            var leaseAgreementResponse = _mapper.Map<LeaseAgreementResponse>(leaseAgreement);

            await _unitOfWork.Leasings.AddLeasingAsync(leaseAgreement);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok(leaseAgreementResponse);
        }

     

        public async Task<Result> DeleteLeasingAsync(Guid leaseAgreementId, CancellationToken cancellationToken)
        {
            LeaseAgreement? leaseAgreement = await _unitOfWork.Leasings.GetLeasingByIdAsync(new LeaseAgreementId(leaseAgreementId));

            if (leaseAgreement is null)
                return Result.Fail(new EntityNotFoundError($"No Lease Agreement = {leaseAgreementId} found"));

            await _unitOfWork.Leasings.DeleteLeasingAsync(new LeaseAgreementId(leaseAgreementId));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }


       
    }
}
