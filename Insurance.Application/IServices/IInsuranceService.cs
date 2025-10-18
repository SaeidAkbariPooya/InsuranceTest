using Insurance.Application.Dtos;

namespace Insurance.Application.IServices
{
    public interface IInsuranceService
    {
        Task<InsuranceRequestDto> CreateInsuranceRequestAsync(CreateInsuranceRequestDto requestDto);
        Task<IEnumerable<InsuranceRequestDto>> GetAllInsuranceRequestsAsync();
    }
}
