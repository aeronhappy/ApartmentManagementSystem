using FluentResults;

namespace ApartmentManagementSystem.SharedKernel.Errors
{
    public class ConflictError(string message) : Error(message)
    {
    }

}
