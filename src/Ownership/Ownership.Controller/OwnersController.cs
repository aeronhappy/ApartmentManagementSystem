using ApartmentManagementSystem.SharedKernel.Errors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Ownership.Application.Commands;
using Ownership.Application.Queries;
using Ownership.Application.Response;
using Ownership.Controller.Request;

namespace Ownership.Controller
{
    [Route("api/buildings")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerCommands _ownerCommands;
        private readonly IOwnerQueries _ownerQueries;

        public OwnersController(IOwnerCommands ownerCommands, IOwnerQueries ownerQueries)
        {
            _ownerCommands = ownerCommands;
            _ownerQueries = ownerQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<OwnerResponse>>> GetListOfOwner([FromQuery] string searchText = "")
        {
            var listOfOwner = await _ownerQueries.GetListOfOwnerResponseAsync();
            return Ok(listOfOwner);
        }

        [HttpGet("{ownerId}")]
        public async Task<ActionResult<OwnerResponse>> GetOwnerById(Guid ownerId)
        {
            var ownerResponse = await _ownerQueries.GetOwnerResponseByIdAsync(ownerId);
            if (ownerResponse is null)
                return NotFound();

            return Ok(ownerResponse);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OwnerResponse>> CreateOwner([FromBody] CreateOwnerRequest request)
        {
            var response =
                await _ownerCommands.AddOwnerAsync(request.Email,request.Name, request.Address, request.ContactNumber, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpDelete("{ownerId}")]
        public async Task<ActionResult> DeleteBuidling(Guid ownerId)
        {
            Result result = await _ownerCommands.DeleteOwnerAsync(ownerId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPut("{ownerId}")]
        public async Task<ActionResult> UpdateBuilding(Guid ownerId, [FromQuery] string name, [FromQuery] string address, [FromQuery] string contactNumber)
        {
            Result result = await _ownerCommands.UpdateOwnerAsync(ownerId, name,address, contactNumber, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }


    }
}
