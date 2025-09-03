using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.Errors;
using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Controller.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.Controller
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentReceiptCommands _paymentReceiptCommands;
        private readonly IPaymentReceiptQueries _paymentReceiptQueries;

        public PaymentsController(IPaymentReceiptCommands paymentReceiptCommands, IPaymentReceiptQueries paymentReceiptQueries)
        {
            _paymentReceiptCommands = paymentReceiptCommands;
            _paymentReceiptQueries = paymentReceiptQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<PaymentReceiptResponse>>> GetListOfPaymentReceipt([FromQuery] string searchText = "")
        {
            var responses = await _paymentReceiptQueries.GetListOfPaymentReceiptResponseAsync(searchText);
            return Ok(responses);
        }

        [HttpGet("receiptByApartment")]
        public async Task<ActionResult<List<PaymentReceiptResponse>>> GetListOfPaymentReceiptByApartment([FromQuery] Guid apartmentId ,[FromQuery] string searchText = "")
        {
            var responses = await _paymentReceiptQueries.GetListOfPaymentReceiptResponseByApartmentAsync(apartmentId, searchText);
            return Ok(responses);
        }

        [HttpGet("receiptByTenant")]
        public async Task<ActionResult<List<PaymentReceiptResponse>>> GetListOfPaymentReceiptByTenant([FromQuery] Guid tenantId ,[FromQuery] string searchText = "")
        {
            var responses = await _paymentReceiptQueries.GetListOfPaymentReceiptResponseByTenantAsync(tenantId, searchText);
            return Ok(responses);
        }


        [HttpGet("receipt/{paymentReceiptId}")]
        public async Task<ActionResult<PaymentReceiptResponse?>> GetPaymnetReceiptById(Guid paymentReceiptId)
        {
            var response = await _paymentReceiptQueries.GetPaymentReceiptResponseByIdAsync(paymentReceiptId);
            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<ActionResult<PaymentReceiptResponse>> CreatePayments([FromBody] CreatePaymentRequest request)
        {
            var response =
                await _paymentReceiptCommands.AddPaymentReceiptAsync(request.InvoiceId, request.TenantId, request.PaymentMethod, HttpContext.RequestAborted);
            return Ok(response);
        }

    }
}
