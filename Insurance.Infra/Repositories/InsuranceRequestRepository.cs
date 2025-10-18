using Insurance.Core.Entities;
using Insurance.Core.IRepositories;
using Insurance.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infra.Repositories
{
    public class InsuranceRequestRepository : IInsuranceRequestRepository
    {
        private readonly InsuranceDbContext _context;

        public InsuranceRequestRepository(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<InsuranceRequest> GetByIdAsync(int id)
        {
            return await _context.InsuranceRequests
                .Include(r => r.Coverages)
                .ThenInclude(rc => rc.Coverage)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<InsuranceRequest>> GetAllAsync()
        {
            return await _context.InsuranceRequests
                .Include(r => r.Coverages)
                .ThenInclude(rc => rc.Coverage)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();
        }

        public async Task<InsuranceRequest> AddAsync(InsuranceRequest request)
        {
            _context.InsuranceRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task UpdateAsync(InsuranceRequest request)
        {
            _context.InsuranceRequests.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
