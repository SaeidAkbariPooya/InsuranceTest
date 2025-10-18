using Insurance.Application.Dtos;
using Insurance.Application.IServices;
using Insurance.Core.Entities;
using Insurance.Core.IRepositories;
using Insurance.Core.IServices;

namespace Insurance.Application.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRequestRepository _requestRepository;
        private readonly IInsuranceCoverageRepository _coverageRepository;
        private readonly IInsuranceCalculator _calculator;

        public InsuranceService(
            IInsuranceRequestRepository requestRepository,
            IInsuranceCoverageRepository coverageRepository,
            IInsuranceCalculator calculator)
        {
            _requestRepository = requestRepository;
            _coverageRepository = coverageRepository;
            _calculator = calculator;
        }

        public async Task<InsuranceRequestDto> CreateInsuranceRequestAsync(CreateInsuranceRequestDto requestDto)
        {
            var coverages = await _coverageRepository.GetAllAsync();
            var coverageDict = coverages.ToDictionary(c => c.Id);

            var requestCoverages = new List<RequestCoverage>();
            var totalPremium = 0m;

            foreach (var selectedCoverage in requestDto.Coverages)
            {
                if (!coverageDict.TryGetValue(selectedCoverage.CoverageId, out var coverage))
                {
                    throw new ArgumentException($"پوشش با شناسه {selectedCoverage.CoverageId} یافت نشد");
                }

                if (selectedCoverage.Capital < coverage.MinCapital || selectedCoverage.Capital > coverage.MaxCapital)
                {
                    throw new ArgumentException(
                        $"سرمایه پوشش {coverage.Title} باید بین {coverage.MinCapital:N0} و {coverage.MaxCapital:N0} باشد");
                }

                var premium = CalculatePremium(coverage.Id, selectedCoverage.Capital);
                totalPremium += premium;

                requestCoverages.Add(new RequestCoverage
                {
                    CoverageId = coverage.Id,
                    Capital = selectedCoverage.Capital,
                    CalculatedPremium = premium
                });
            }

            var insuranceRequest = new InsuranceRequest
            {
                Title = requestDto.Title,
                RequestDate = DateTime.Now,
                TotalPremium = totalPremium,
                Coverages = requestCoverages
            };

            var createdRequest = await _requestRepository.AddAsync(insuranceRequest);

            return MapToDto(createdRequest);
        }

        public async Task<IEnumerable<InsuranceRequestDto>> GetAllInsuranceRequestsAsync()
        {
            var requests = await _requestRepository.GetAllAsync();
            return requests.Select(MapToDto);
        }

        private decimal CalculatePremium(int coverageId, decimal capital)
        {
            return coverageId switch
            {
                1 => _calculator.CalculateSurgeryPremium(capital),
                2 => _calculator.CalculateDentalPremium(capital),
                3 => _calculator.CalculateHospitalizationPremium(capital),
                _ => throw new ArgumentException("شناسه پوشش معتبر نیست")
            };
        }

        private InsuranceRequestDto MapToDto(InsuranceRequest request)
        {
            return new InsuranceRequestDto
            {
                Id = request.Id,
                Title = request.Title,
                RequestDate = request.RequestDate,
                TotalPremium = request.TotalPremium,
                Coverages = request.Coverages.Select(rc => new RequestCoverageDto
                {
                    CoverageTitle = rc.Coverage.Title,
                    Capital = rc.Capital,
                    CalculatedPremium = rc.CalculatedPremium
                }).ToList()
            };
        }
    }
}
