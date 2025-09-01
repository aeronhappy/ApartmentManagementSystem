using Tenancy.Domain.Entities;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Domain.Repositories
{
    public interface ILeasingRepository
    {
        Task<LeaseAgreement?> GetLeasingByIdAsync(LeaseAgreementId id);
        Task AddLeasingAsync(LeaseAgreement unit);
        Task DeleteLeasingAsync(LeaseAgreementId id);
    }
}
