using Insurance.Core.Entities;
using Insurance.Core.IRepositories;
using Insurance.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infra.Repositories
{
    public class InsuranceCoverageRepository : IInsuranceCoverageRepository
    {
        private readonly InsuranceDbContext _context;

        public InsuranceCoverageRepository(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<InsuranceCoverage> GetByIdAsync(int id)
        {
            return await _context.InsuranceCoverages.FindAsync(id);
        }

        public async Task<IEnumerable<InsuranceCoverage>> GetAllAsync()
        {
            return await _context.InsuranceCoverages.ToListAsync();
        }
    }
}
