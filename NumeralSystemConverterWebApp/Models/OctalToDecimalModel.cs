using System.ComponentModel.DataAnnotations;

namespace NumeralSystemConverterWebApp.Models
{
    public class OctalToDecimalModel
    {
        [Display(Name = "Octal Number")]
        [Required(ErrorMessage = "Please enter a valid Octal Number.")]
        public string? OctalNumber { get; set; }

        [Display(Name = "Decimal Equivalent")]
        public string? DecimalEquivalent { get; set; }
    }
}
