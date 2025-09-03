using FluentResults;

namespace Property.Application.Errors
{
    public class NoOwnerError(string message) : Error(message)
    {
    }

}
