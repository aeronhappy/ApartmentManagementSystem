using ApartmentManagementSystem.SharedKernel.Exception;

namespace Property.Domain.Exception
{
    public class NoOwnerException(string message) : DomainException(message)
    {

    }
}
