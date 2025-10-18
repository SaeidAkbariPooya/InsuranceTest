using Insurance.Core.IServices;

namespace Insurance.Infra.Services
{
    public class InsuranceCalculatorService : IInsuranceCalculatorService
    {
        public decimal CalculateSurgeryPremium(decimal capital) => capital * 0.00520m;
        public decimal CalculateDentalPremium(decimal capital) => capital * 0.00420m;
        public decimal CalculateHospitalizationPremium(decimal capital) => capital * 0.00400m;
    }
}
