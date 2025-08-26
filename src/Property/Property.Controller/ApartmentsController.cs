using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.Errors;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Commands;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Controller.Request;

namespace Property.Controller
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentCommands _apartmentCommands;
        private readonly IApartmentQueries _apartmentQueries;

        public ApartmentsController(IApartmentCommands apartmentCommands, IApartmentQueries apartmentQueries)
        {
            _apartmentCommands = apartmentCommands;
            _apartmentQueries = apartmentQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<ApartmentResponse>>> GetListOfUnit([FromQuery] string searchText = "")
        {
            var listOfApartment = await _apartmentQueries.GetListOfApartmentResponseAsync();
            return Ok(listOfApartment);
        }

        [HttpGet("{apartmentId}")]
        public async Task<ActionResult<ApartmentResponse>> GetUnitById(Guid apartmentId)
        {
            var apartmentResponse = await _apartmentQueries.GetApartmentResponseByIdAsync(apartmentId);
            if (apartmentResponse is null)
                return NotFound();

            return Ok(apartmentResponse);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ApartmentResponse>> CreateUnit([FromBody] CreateApartmentRequest request)
        {
            var response =
                await _apartmentCommands.CreateApartmentAsync(request.BuildingId, request.Number, request.Floor, request.AreaSqm, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpDelete("{apartmentId}")]
        public async Task<ActionResult> DeleteUnit(Guid apartmentId)
        {
            Result result = await _apartmentCommands.DeleteApartmentAsync(apartmentId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPut("{apartmentId}")]
        public async Task<ActionResult> UpdateUnit(Guid apartmentId, [FromQuery] int number, [FromQuery] int floor, [FromQuery] int areaSqm)
        {
            Result result = await _apartmentCommands.UpdateApartmentAsync(apartmentId, number, floor, areaSqm, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPost("{apartmentId}/assignOwner/{ownerId}")]
        public async Task<ActionResult> AssignOwner(Guid apartmentId, Guid ownerId)
        {
            Result result = await _apartmentCommands.AssignOwnerAsync(apartmentId, ownerId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPost("{apartmentId}/changeStatusToMaintenance")]
        public async Task<ActionResult> ChangeStatusToMaintenance(Guid apartmentId)
        {
            Result result = await _apartmentCommands.ChangeStatusAsync(apartmentId, ApartmentStatus.UnderMaintenance, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPost("{apartmentId}/changeStatusToVacant")]
        public async Task<ActionResult> ChangeStatusToVacant(Guid apartmentId)
        {
            Result result = await _apartmentCommands.ChangeStatusAsync(apartmentId, ApartmentStatus.Vacant, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }


    }
}
