using Microsoft.AspNetCore.Mvc;
using NumeralSystemConverter;
using NumeralSystemConverterWebApp.Models;
namespace NumeralSystemConverterWebApp.Controllers
{
    public class ConversionController : Controller
    {

        //Define method signature to be invoked after resetting the form
        //A Delegates used to define a contract
        private delegate IActionResult ReloadPageAction();

        private IActionResult ResetForm(ReloadPageAction pageAction)
        {
            // Invoke the provided action to reload the page
            return pageAction.Invoke();
        }

        #region -- Decimal To Binary
        [HttpGet]
        public IActionResult DecimalToBinary()
        {
          
            return View(new DecimalToBinaryModel());
        }

        [HttpPost]
        public IActionResult DecimalToBinary(DecimalToBinaryModel model)
        {
            #region -- old code --
            //try
            //{
            //    if (int.TryParse(model.DecimalNumber, out var decimalNumber))
            //    {
            //        model.BinaryEquivalent = BaseConverter.DecimalToBinary(decimalNumber);

            //        if (!ModelState.IsValid)
            //        {
            //            return View(model);
            //        }
            //    }
            //}
            //catch(OverflowException)
            //{
            //    ViewBag.Error = "The number was outside the range of a 32-bit signed integer";
            //}
            //catch(Exception)
            //{
            //    ViewBag.Error = "Unexpected Error";
            //}
           
            //return View(model);
            #endregion

            #region -- revised code to make robust and maintainable
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                if (int.TryParse(model.DecimalNumber, out var decimalNumber))
                {
                    model.BinaryEquivalent = BaseConverter.DecimalToBinary(decimalNumber);
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("DecimalNumber", "Invalid decimal number format");
                }
            }
            catch(OverflowException)
            {
                ModelState.AddModelError("DecimalNumber", "The number was outside the range of a 32-bit signed integer");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Unexpected Error");
            }

            return View(model);
            #endregion
        }

        /// <summary>
        /// Reloading the DecimalToBinary Page
        /// </summary>
        /// <returns>DecimalToBinary Form Empty </returns>
        [HttpPost]
        public IActionResult ResetDecimalToBinaryForm()
        {
            // Redirect to the same action to reload the page
            return ResetForm(() => RedirectToAction("DecimalToBinary"));
        }

        #endregion

        #region -- Binary To Decimal
        [HttpGet]
        public IActionResult BinaryToDecimal()
        {
            return View(new BinaryToDecimalModel());
        }

        [HttpPost]
        public IActionResult BinaryToDecimal(BinaryToDecimalModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                model.DecimalEquivalent = BaseConverter.BinaryToDecimal(model.BinaryNumber).ToString();
                return View(model);
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Unexpected Error");
            }
            return View(model);
        }


        /// <summary>
        /// Reloading Binary To Decimal Page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ResetBinaryToDecimalForm()
        {
            // Redirect to the same action to reload the page
            return ResetForm(() => RedirectToAction("BinaryToDecimal"));
        }
        #endregion
    }
}
