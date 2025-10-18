
namespace Insurance.Core.Entities
{
    public class InsuranceRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal TotalPremium { get; set; }

        public virtual ICollection<RequestCoverage> Coverages { get; set; }
    }
}
