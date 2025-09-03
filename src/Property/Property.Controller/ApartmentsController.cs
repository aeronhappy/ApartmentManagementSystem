using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.Errors;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Commands;
using Property.Application.Errors;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Controller.Request;
using Property.Domain.Exception;

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
        public async Task<ActionResult<List<ApartmentResponse>>> GetListOfApartment([FromQuery] ApartmentStatus? apartmentStatus,[FromQuery] string searchText = "")
        {
            var listOfApartment = await _apartmentQueries.GetListOfApartmentResponseAsync(searchText ,apartmentStatus);
            return Ok(listOfApartment);
        }

        [HttpGet("Building/{buildingId}")]
        public async Task<ActionResult<List<ApartmentResponse>>> GetListOfApartmentByBuilding(Guid buildingId,[FromQuery] string searchText = "")
        {
            var listOfApartment = await _apartmentQueries.GetListOfApartmentResponseByBuildingAsync(searchText, buildingId);
            return Ok(listOfApartment);
        }

        [HttpGet("{apartmentId}")]
        public async Task<ActionResult<ApartmentResponse>> GetApartmentById(Guid apartmentId)
        {
            var apartmentResponse = await _apartmentQueries.GetApartmentResponseByIdAsync(apartmentId);
            if (apartmentResponse is null)
                return NotFound();

            return Ok(apartmentResponse);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ApartmentResponse>> CreateApartment([FromBody] CreateApartmentRequest request)
        {
            Result<ApartmentResponse> result =
                await _apartmentCommands.CreateApartmentAsync(request.BuildingId, request.Number, request.Floor, request.AreaSqm, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();
                return error switch
                {
                    EntityNotFoundError => NotFound(error.Message),
                    OccupiedStatusCannotChangeException => Conflict(error.Message),
                    Error => BadRequest(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }
            return Ok(result);
        }


        [HttpDelete("{apartmentId}")]
        public async Task<ActionResult> DeleteApartment(Guid apartmentId)
        {
            Result result = await _apartmentCommands.DeleteApartmentAsync(apartmentId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPut("{apartmentId}")]
        public async Task<ActionResult> UpdateApartment(Guid apartmentId, [FromQuery] int number, [FromQuery] int floor, [FromQuery] int areaSqm)
        {
            Result result = await _apartmentCommands.UpdateApartmentAsync(apartmentId, number, floor, areaSqm, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();
                return error switch
                {
                    EntityNotFoundError => NotFound(error.Message),
                    OccupiedStatusCannotChangeException => Conflict(error.Message),
                    Error => BadRequest(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpPut("{apartmentId}/assignOwner/{ownerId}")]
        public async Task<ActionResult> AssignOwner(Guid apartmentId, Guid ownerId)
        {
            Result result = await _apartmentCommands.AssignOwnerAsync(apartmentId, ownerId, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();
                return error switch
                {
                    EntityNotFoundError => NotFound(error.Message),
                    HasOwnerAlreadyError => Conflict(error.Message),
                    Error => BadRequest(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpPut("{apartmentId}/removeOwnder/{ownerId}")]
        public async Task<ActionResult> RemoveOwner(Guid apartmentId, Guid ownerId)
        {
            Result result = await _apartmentCommands.RemoveOwnerToApartmentAsync(apartmentId, ownerId, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();
                return error switch
                {
                    EntityNotFoundError => NotFound(error.Message),
                    NoOwnerError => Conflict(error.Message),
                    Error => BadRequest(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpPut("{apartmentId}/changeStatusToMaintenance")]
        public async Task<ActionResult> ChangeStatusToMaintenance(Guid apartmentId)
        {
            Result result = await _apartmentCommands.ChangeStatusAsync(apartmentId, ApartmentStatus.UnderMaintenance, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();
                return error switch
                {
                    EntityNotFoundError => NotFound(error.Message),
                    OccupiedStatusCannotChangeException => Conflict(error.Message),
                    Error => BadRequest(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpPut("{apartmentId}/changeStatusToVacant")]
        public async Task<ActionResult> ChangeStatusToVacant(Guid apartmentId)
        {
            Result result = await _apartmentCommands.ChangeStatusAsync(apartmentId, ApartmentStatus.Vacant, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();
                return error switch
                {
                    EntityNotFoundError => NotFound(error.Message),
                    OccupiedStatusCannotChangeException => Conflict(error.Message),
                    Error => BadRequest(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }


    }
}
