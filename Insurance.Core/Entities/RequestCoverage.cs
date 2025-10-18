
namespace Insurance.Core.Entities
{
    public class RequestCoverage
    {
        public int Id { get; set; }
        public int InsuranceRequestId { get; set; }
        public int CoverageId { get; set; }
        public decimal Capital { get; set; }
        public decimal CalculatedPremium { get; set; }

        public virtual InsuranceRequest InsuranceRequest { get; set; }
        public virtual InsuranceCoverage Coverage { get; set; }
    }
}
