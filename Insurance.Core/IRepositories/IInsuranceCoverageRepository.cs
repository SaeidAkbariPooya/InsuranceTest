using Insurance.Core.Entities;

namespace Insurance.Core.IRepositories
{
    public interface IInsuranceCoverageRepository
    {
        Task<InsuranceCoverage> GetByIdAsync(int id);
        Task<IEnumerable<InsuranceCoverage>> GetAllAsync();
    }
}
