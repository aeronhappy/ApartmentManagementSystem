using ApartmentManagementSystem.SharedKernel.Entitites;
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
    public class TenantCommands : ITenantCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TenantCommands(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Result<TenantResponse>> AddTenantAsync(string email, string name, string address,int gender,string contactNumber, CancellationToken cancellationToken)
        {
            var tenant = Tenant.Create(email, name, address,gender, contactNumber);
            var tenantResponse = _mapper.Map<TenantResponse>(tenant);
            await _unitOfWork.Tenants.AddTenantAsync(tenant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok(tenantResponse);
        }

       

        public async Task<Result> DeleteTenantAsync(Guid tenantId, CancellationToken cancellationToken)
        {
            Tenant? tenant = await _unitOfWork.Tenants.GetTenantByIdAsync(new TenantId(tenantId));

            if (tenant is null)
                return Result.Fail(new EntityNotFoundError($"No Tenant = {tenantId} found"));

            await _unitOfWork.Tenants.DeleteTenantAsync(new TenantId(tenantId));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

      

        public async Task<Result> UpdateTenantAsync(Guid tenantId, string name, string address, string contactNumber, CancellationToken cancellationToken)
        {
            Tenant? tenant = await _unitOfWork.Tenants.GetTenantByIdAsync(new TenantId(tenantId));

            if (tenant is null)
                return Result.Fail(new EntityNotFoundError($"No Tenant = {tenantId} found"));

            tenant.Update(name, address, contactNumber);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
