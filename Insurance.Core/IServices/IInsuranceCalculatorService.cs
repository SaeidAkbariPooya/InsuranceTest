
namespace Insurance.Core.IServices
{
    public interface IInsuranceCalculatorService
    {
        decimal CalculateSurgeryPremium(decimal capital);
        decimal CalculateDentalPremium(decimal capital);
        decimal CalculateHospitalizationPremium(decimal capital);
    }
}
