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
    public class InvoiceCommands : IInvoiceCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceCommands(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Result> CreatePaymentInvoice(Guid InvoiceId)
        {
            throw new NotImplementedException();
        }
    }
}
