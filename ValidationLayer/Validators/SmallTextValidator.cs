using SharedConfig.Messages;
using System.ComponentModel.DataAnnotations;

namespace ValidationLayer.Validators
{
    // validate small text for address, street name, etc.
    public class SmallTextValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_FORMAT_NOT_VALID;
            bool isLengthValid = AppValidator.ValidateString(value.ToString(), AppValidations.SMALL_TEXT_MIN_LENGTH, AppValidations.LONG_TEXT_MAX_LENGTH);
            return isLengthValid;
        }
    }
}
