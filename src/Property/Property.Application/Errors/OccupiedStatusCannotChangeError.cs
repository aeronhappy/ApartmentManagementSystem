using FluentResults;

namespace Property.Application.Errors
{
    public class OccupiedStatusCannotChangeError(string message) : Error(message)
    {
    }

}
