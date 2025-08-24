using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface ILeasingRepository
    {
        Task<LeaseAgreement?> GetLeasingByIdAsync(LeaseAgreementId id);
        Task AddLeasingAsync(LeaseAgreement unit);
        Task DeleteLeasingAsync(LeaseAgreementId id);
    }
}
