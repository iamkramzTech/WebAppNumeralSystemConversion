using System.ComponentModel.DataAnnotations;

namespace NumeralSystemConverterWebApp.Models
{
    public class DecimalToBinaryModel
    {
        [Display(Name ="Decimal Number")]
        [Required(ErrorMessage = "Please enter a decimal number.")]
        public string DecimalNumber { get; set; }

        [Display(Name ="Binary Equivalent")]
        public string BinaryEquivalent { get; set; }
    }
}
