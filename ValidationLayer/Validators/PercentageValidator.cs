using SharedConfig.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationLayer.Validators
{
    // validate percentage number such as discount percentage
    public class PercentageValidator : ValidationAttribute
    {

        private readonly bool isNegative;
        public PercentageValidator(bool isNegative = false)
        {
            this.isNegative = isNegative;
        }

        public override bool IsValid(object value)
        {
            bool isValid;

            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_FORMAT_NOT_VALID;

            if(isNegative)
                isValid = AppValidator.ValidateNumber(value, -100, 100);
            else
                isValid = AppValidator.ValidateNumber(value, 0, 100);

            return isValid;
        }
    }
}
