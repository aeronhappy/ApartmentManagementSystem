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
    [Route("api/leasings")]
    [ApiController]
    public class LeasingsController : ControllerBase
    {
        private readonly ILeasingCommands _leasingCommands;
        private readonly ILeasingQueries _leasingQueries;

        public LeasingsController(ILeasingCommands leasingCommands, ILeasingQueries leasingQueries)
        {
            _leasingCommands = leasingCommands;
            _leasingQueries = leasingQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<LeaseAgreementResponse>>> GetListOfLeaseAgreement([FromQuery] string searchText = "")
        {
            var responses = await _leasingQueries.GetListOfLeaseAgreementResponseAsync();
            return Ok(responses);
        }

        [HttpGet("{leaseAgreementId}")]
        public async Task<ActionResult<LeaseAgreementResponse>> GetLeaseAgreementById(Guid leaseAgreementId)
        {
            var leaseAgreementResponse = await _leasingQueries.GetLeaseAgreementResponseByIdAsync(leaseAgreementId);
            if (leaseAgreementResponse is null)
                return NotFound();

            return Ok(leaseAgreementResponse);
        }

        [HttpPost("create")]
        public async Task<ActionResult<LeaseAgreementResponse>> CreateLeaseAgreement([FromBody] CreateLeaseAgreementRequest request)
        {
            var response =
                await _leasingCommands.CreateLeasingAsync(request.TenantId, request.UnitId, request.DateStart,request.MonthlyRent, request.LeaseTermInMonths, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpDelete("{leaseAgreementId}")]
        public async Task<ActionResult> DeleteLeaseAgreement(Guid leaseAgreementId)
        {
            Result result = await _leasingCommands.DeleteLeasingAsync(leaseAgreementId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

    


    }
}
