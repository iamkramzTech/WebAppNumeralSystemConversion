using Microsoft.AspNetCore.Mvc;
using NumeralSystemConverter;
using NumeralSystemConverterWebApp.Models;
namespace NumeralSystemConverterWebApp.Controllers
{
    public class ConversionController : Controller
    {
        [HttpGet]
        public IActionResult DecimalToBinary()
        {
          
            return View(new DecimalToBinaryModel());
        }

        [HttpPost]
        public IActionResult DecimalToBinary(DecimalToBinaryModel model)
        {
            //var decimalNumberParse = int.Parse(model.DecimalNumber);

            //model.BinaryEquivalent = BaseConverter.DecimalToBinary(decimalNumberParse);

            //if (ModelState.IsValid)
            //{
     
            //    // When ModelState is valid, return the view with the updated model
            //    return View(model);
               
            //}

            //return View(model);

            if(int.TryParse(model.DecimalNumber, out var decimalNumber))
            {
                model.BinaryEquivalent = BaseConverter.DecimalToBinary(decimalNumber);

                if(!ModelState.IsValid)
                {
                    return View(model);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Reloading the DecimalToBinary Page
        /// </summary>
        /// <returns>DecimalToBinary Form Empty </returns>
        [HttpPost]
        public IActionResult ResetDecimalToBinaryForm()
        {
            // Redirect to the same action to reload the page
            return RedirectToAction("DecimalToBinary");
        }

    }
}
