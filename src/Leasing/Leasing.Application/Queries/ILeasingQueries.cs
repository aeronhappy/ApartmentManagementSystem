using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface ILeasingQueries
    {
        Task<List<LeaseAgreementResponse>> GetListOfLeaseAgreementResponseAsync();
        Task<LeaseAgreementResponse?> GetLeaseAgreementResponseByIdAsync(Guid id);
    }
}
