
namespace Insurance.Core.Entities
{
    public class InsuranceCoverage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal MinCapital { get; set; }
        public decimal MaxCapital { get; set; }
        public decimal Rate { get; set; }

        public virtual ICollection<RequestCoverage> RequestCoverages { get; set; }
    }
}
