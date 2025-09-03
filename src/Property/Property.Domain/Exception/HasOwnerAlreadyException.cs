using ApartmentManagementSystem.SharedKernel.Exception;

namespace Property.Domain.Exception
{
    public class HasOwnerAlreadyException(string message) : DomainException(message)
    {

    }
}
