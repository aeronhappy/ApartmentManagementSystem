using FluentResults;

namespace Property.Application.Errors
{
    public class UnitNumberIsAlreadyTakenInSameFloorError(string message) : Error(message)
    {
    }

}
