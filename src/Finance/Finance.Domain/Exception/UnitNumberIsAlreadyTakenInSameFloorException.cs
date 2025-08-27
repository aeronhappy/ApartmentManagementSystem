using ApartmentManagementSystem.SharedKernel.Exception;

namespace Property.Domain.Exception
{
    public class UnitNumberIsAlreadyTakenInSameFloorException(string message) : DomainException(message)
    {
    }
}
