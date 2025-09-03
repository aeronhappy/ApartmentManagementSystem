using FluentResults;

namespace Property.Application.Errors
{
    public class HasOwnerAlreadyError(string message) : Error(message)
    {
    }

}
