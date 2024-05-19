using System.ComponentModel.DataAnnotations;

namespace NumeralSystemConverterWebApp.Models
{
    public class DecimalToOctalModel
    {
        [Display(Name = "Decimal Number")]
        [Required(ErrorMessage = "Please enter a decimal number.")]
        public string? DecimalNumber { get; set; }

        [Display(Name = "Octal Equivalent")]
        public string? OctalEquivalent { get; set; }
    }
}
