using System.ComponentModel.DataAnnotations;

namespace Insurance.Application.Dtos
{
    public class CreateInsuranceRequestDto
    {
        [Required(ErrorMessage = "عنوان درخواست الزامی است")]
        [StringLength(200, ErrorMessage = "عنوان نمی‌تواند بیش از 200 کاراکتر باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "حداقل یک پوشش باید انتخاب شود")]
        [MinLength(1, ErrorMessage = "حداقل یک پوشش باید انتخاب شود")]
        public List<CoverageSelectionDto> Coverages { get; set; }
    }
}
