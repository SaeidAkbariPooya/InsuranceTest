using Insurance.Core.Entities;

namespace Insurance.Core.IRepositories
{
    public interface IInsuranceRequestRepository
    {
        Task<InsuranceRequest> GetByIdAsync(int id);
        Task<IEnumerable<InsuranceRequest>> GetAllAsync();
        Task<InsuranceRequest> AddAsync(InsuranceRequest request);
        Task UpdateAsync(InsuranceRequest request);
    }
}
