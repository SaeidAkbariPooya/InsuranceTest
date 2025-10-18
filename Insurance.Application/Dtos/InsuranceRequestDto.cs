
namespace Insurance.Application.Dtos
{
    public class InsuranceRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPremium { get; set; }
        public List<RequestCoverageDto> Coverages { get; set; }
    }
}
