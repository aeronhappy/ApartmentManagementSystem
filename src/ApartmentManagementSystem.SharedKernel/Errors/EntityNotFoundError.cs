using FluentResults;

namespace ApartmentManagementSystem.SharedKernel.Errors
{
    public class EntityNotFoundError(string message) : Error(message)
    {

    }
}
