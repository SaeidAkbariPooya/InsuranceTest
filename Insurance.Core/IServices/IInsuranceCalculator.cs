
namespace Insurance.Core.IServices
{
    public interface IInsuranceCalculator
    {
        decimal CalculateSurgeryPremium(decimal capital);
        decimal CalculateDentalPremium(decimal capital);
        decimal CalculateHospitalizationPremium(decimal capital);
    }
}
