using ApartmentManagementSystem.SharedKernel.Exception;

namespace Property.Domain.Exception
{
    public class OccupiedStatusCannotChangeException(string message) : DomainException(message)
    {

    }
}
