using SharedConfig.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationLayer.Validators
{
    // Validate that number fall into range between minValue and maxValue
    public class NumberRangeValidator : ValidationAttribute
    {
        private readonly double MinValue;
        private readonly double MaxValue;
        public NumberRangeValidator(double MinValue = AppValidations.POSITVE_NUM_MIN_VALUE_0, double MaxValue = AppValidations.NUM_MAX_VALUE)
        {
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
        }

        public override bool IsValid(object value)
        {
            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_FORMAT_NOT_VALID;
            bool isValid = AppValidator.ValidateNumber(value, MinValue, MaxValue);
            return isValid;
        }
    }
}
