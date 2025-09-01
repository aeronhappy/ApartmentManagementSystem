using ApartmentManagementSystem.SharedKernel.Errors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Tenancy.Application.Commands;
using Tenancy.Application.Queries;
using Tenancy.Application.Response;

namespace Tenancy.Controller
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantCommands _tenantCommands;
        private readonly ITenantQueries _tenantQueries;

        public TenantsController(ITenantCommands tenantCommands, ITenantQueries tenantQueries)
        {
            _tenantCommands = tenantCommands;
            _tenantQueries = tenantQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<TenantResponse>>> GetListOfTenant([FromQuery] string searchText = "")
        {
            var listOfTenant = await _tenantQueries.GetListOfTenantResponseAsync();
            return Ok(listOfTenant);
        }

        [HttpGet("{tenantId}")]
        public async Task<ActionResult<TenantResponse>> GetTenantById(Guid tenantId)
        {
            var response = await _tenantQueries.GetTenantResponseByIdAsync(tenantId);
            if (response is null)
                return NotFound();

            return Ok(response);
        }

        //[HttpPost("create")]
        //public async Task<ActionResult<TenantResponse>> CreateTenant([FromBody] CreateTenantRequest request)
        //{
        //    var response =
        //        await _tenantCommands.AddTenantAsync(request.Email,request.Name, request.Address,request.Gender, request.ContactNumber, HttpContext.RequestAborted);
        //    return Ok(response);
        //}

        [HttpDelete("{tenantId}")]
        public async Task<ActionResult> DeleteTenant(Guid tenantId)
        {
            Result result = await _tenantCommands.DeleteTenantAsync(tenantId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPut("{tenantId}")]
        public async Task<ActionResult> UpdateTenant(Guid tenantId, [FromQuery] string name, [FromQuery] string address, [FromQuery] string contactNumber)
        {
            Result result = await _tenantCommands.UpdateTenantAsync(tenantId, name,address, contactNumber, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }


    }
}
