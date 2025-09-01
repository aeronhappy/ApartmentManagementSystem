using ApartmentManagementSystem.Contracts.Services;
using ApartmentManagementSystem.SharedKernel.Errors;
using AutoMapper;
using FluentResults;
using Tenancy.Application.Commands;
using Tenancy.Application.Response;
using Tenancy.Domain.Entities;
using Tenancy.Domain.Repositories;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Application.CommandHandler
{
    public class TenantCommands : ITenantCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public TenantCommands(IUnitOfWork unitOfWork , IMapper mapper, IDomainEventPublisher _domainEventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._domainEventPublisher = _domainEventPublisher;
        }


        public async Task<Result<TenantResponse>> AddTenantAsync(Guid id, string email, string name, string address,int gender,string contactNumber, CancellationToken cancellationToken)
        {
            var tenant = Tenant.Create(id,email, name, address,gender, contactNumber);
            var tenantResponse = _mapper.Map<TenantResponse>(tenant);
            await _unitOfWork.Tenants.AddTenantAsync(tenant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _domainEventPublisher.PublishAsync(tenant.DomainEvents, default);
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
