using System.ComponentModel.DataAnnotations;

namespace NumeralSystemConverterWebApp.Models
{
    public class BinaryToDecimalModel
    {
        [Display(Name = "Binary Number")]
        [Required(ErrorMessage = "Please enter a valid Binary Number.")]
        public string? BinaryNumber { get; set; }

        [Display(Name = "Decimal Equivalent")]
        public string? DecimalEquivalent { get; set; }
    }
}
