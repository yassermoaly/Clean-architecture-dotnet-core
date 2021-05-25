using SharedConfig.Messages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ValidationLayer.Validators
{
    // Validate password and it's length
    public class PasswordValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_PASSWORD_NOT_VALID;
            bool isValid = value.ToString().Length > AppValidations.PASSWORD_MIN_LENGTH && value.ToString().Length < AppValidations.PASSWORD_MAX_LENGTH;

            bool isFormatValid = !Regex.Match(value.ToString(),
                                 @"[ ]+")
                              .Success;

            
            return isValid && isFormatValid;
        }
    }
}
