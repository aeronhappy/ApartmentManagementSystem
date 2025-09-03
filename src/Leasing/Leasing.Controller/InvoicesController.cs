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
    [Route("api/invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceQueries _invoiceQueries;

        public InvoicesController( IInvoiceQueries invoiceQueries)
        {
            _invoiceQueries = invoiceQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<InvoiceResponse>>> GetListOfInvoice([FromQuery] string searchText = "")
        {
            var responses = await _invoiceQueries.GetListOfInvoiceResponseAsync(searchText);
            return Ok(responses);
        }

        [HttpGet("ByApartment")]
        public async Task<ActionResult<List<InvoiceResponse>>> GetListOfInvoiceByApartment([FromQuery] Guid apartmentId ,[FromQuery] string searchText = "")
        {
            var responses = await _invoiceQueries.GetListOfInvoiceResponseByApartmentAsync(apartmentId, searchText);
            return Ok(responses);
        }

        [HttpGet("ByTenant")]
        public async Task<ActionResult<List<InvoiceResponse>>> GetListOfInvoiceByTenant( [FromQuery] Guid tenantId ,[FromQuery] string searchText = "")
        {
            var responses = await _invoiceQueries.GetListOfInvoiceResponseByTenantAsync(tenantId,searchText);
            return Ok(responses);
        }


        [HttpGet("{paymentReceiptId}")]
        public async Task<ActionResult<InvoiceResponse?>> GetInvoiceById(Guid paymentReceiptId)
        {
            var response = await _invoiceQueries.GetInvoiceResponseByIdAsync(paymentReceiptId);
            if (response is null)
                return NotFound();

            return Ok(response);
        }

    }
}
