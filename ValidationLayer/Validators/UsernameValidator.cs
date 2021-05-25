using GlobalHelpers.Helpers;
using SharedConfig.Messages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ValidationLayer.Validators
{
    // Validate username with it's custom rules
    public class UsernameValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool isValid;
            ErrorMessage = Errors.E_USERNAME_NOT_VALID;
            isValid = Regex.Match(value.EmptyIfNull(), @"^(^[a-zA-Z][0-9a-zA-Z.]*|)$").Success;
            if (!isValid)
                return false;

            // cahnge error message here if you want
            isValid = AppValidator.ValidateString(value.EmptyIfNull(), AppValidations.NORMAL_TEXT_MIN_LENGTH, AppValidations.NORMAL_TEXT_MAX_LENGTH);

            return isValid;
        }
    }
}
