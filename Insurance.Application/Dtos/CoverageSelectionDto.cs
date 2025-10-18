using System.ComponentModel.DataAnnotations;

namespace Insurance.Application.Dtos
{
    public class CoverageSelectionDto
    {
        [Required(ErrorMessage = "شناسه پوشش الزامی است")]
        [Range(1, 3, ErrorMessage = "شناسه پوشش معتبر نیست")]
        public int CoverageId { get; set; }

        [Required(ErrorMessage = "سرمایه الزامی است")]
        public decimal Capital { get; set; }
    }
}
