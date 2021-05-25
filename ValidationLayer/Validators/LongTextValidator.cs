using SharedConfig.Messages;
using System.ComponentModel.DataAnnotations;

namespace ValidationLayer.Validators
{
    // Validate long text for notes, description, etc.
    public class LongTextValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_FORMAT_NOT_VALID;
            bool isLengthValid = AppValidator.ValidateString(value.ToString(), AppValidations.LONG_TEXT_MIN_LENGTH, AppValidations.LONG_TEXT_MAX_LENGTH);
            return isLengthValid;
        }
    }
}
