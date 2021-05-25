using SharedConfig.Messages;
using System.ComponentModel.DataAnnotations;

namespace ValidationLayer.Validators
{
    // Validate that value is numaric, is negative or at lest one
    public class NumberValidator : ValidationAttribute
    {

        private readonly bool isNegative;
        private readonly bool atLeastOne;
        public NumberValidator(bool isNegative = false, bool atLeastOne = false)
        {
            this.isNegative = isNegative;
            this.atLeastOne = atLeastOne;
        }

        public override bool IsValid(object value)
        {
            bool isValid;

            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_FORMAT_NOT_VALID;

            if(isNegative)
                isValid = AppValidator.ValidateNumber(value, AppValidations.NEGATIVE_NUM_MIN_VALUE, AppValidations.NUM_MAX_VALUE);
            else
            {
                if(atLeastOne)
                    isValid = AppValidator.ValidateNumber(value, AppValidations.POSITVE_NUM_MIN_VALUE_1, AppValidations.NUM_MAX_VALUE);
                else
                    isValid = AppValidator.ValidateNumber(value, AppValidations.POSITVE_NUM_MIN_VALUE_0, AppValidations.NUM_MAX_VALUE);
            }

            return isValid;
        }
    }
}
