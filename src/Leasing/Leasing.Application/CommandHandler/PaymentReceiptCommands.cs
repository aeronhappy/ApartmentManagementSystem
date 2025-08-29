using ApartmentManagementSystem.SharedKernel.Entitites;
using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.Errors;
using AutoMapper;
using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using System.Net;

namespace Leasing.Application.CommandHandler
{
    public class PaymentReceiptCommands : IPaymentReceiptCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentReceiptCommands(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PaymentReceiptResponse>> AddPaymentReceiptAsync(Guid invoiceId,Guid tenantId, PaymentMethod paymentMethod ,CancellationToken cancellationToken)
        {
            Tenant? tenant = await _unitOfWork.Tenants.GetTenantByIdAsync(new TenantId(tenantId));

            if (tenant is null)
                return Result.Fail(new EntityNotFoundError($"No Tenants = {tenantId} found"));

            Invoice? invoice = await _unitOfWork.Invoices.GetInvoiceByIdAsync(new InvoiceId(invoiceId));

            if(invoice is null)
                return Result.Fail(new EntityNotFoundError($"No Invoice = {invoiceId} found"));
            
            if(invoice.LeaseAgreement.TenantId.Value != tenantId)
                return Result.Fail(new EntityNotFoundError($"Wrong Invoice of tenant"));

         
            var paymentReceipt = PaymentReceipt.Create(invoiceId, invoice.Amount, paymentMethod);
            var paymentReceiptResponse = _mapper.Map<PaymentReceiptResponse>(paymentReceipt);
            invoice.AttachReceipt(paymentReceipt);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok(paymentReceiptResponse);
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
