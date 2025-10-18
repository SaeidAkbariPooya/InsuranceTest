
namespace Insurance.Application.Dtos
{
    public class RequestCoverageDto
    {
        public string CoverageTitle { get; set; }
        public decimal Capital { get; set; }
        public decimal CalculatedPremium { get; set; }
    }
}
