using SharedConfig.Messages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ValidationLayer.Validators
{
    // Validate name for FirstName_EN, LastName_AR, etc.
    public class NameValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ErrorMessage = Errors.E_FORMAT_NOT_VALID;
           
            // Allow null or empty and validate required in a seprated validation
            if(string.IsNullOrEmpty(value.ToString()))
                return true;

            // Allow English and Arabic chars
            bool isFormatValid = Regex.Match(value.ToString(),
                                    @"^[a-zA-Z\u0621-\u064Aa][0-9a-zA-Z\u0621-\u064Aa ]+$").Success;

            bool isLengthValid = AppValidator.ValidateString(value.ToString(), AppValidations.NORMAL_TEXT_MIN_LENGTH, AppValidations.NORMAL_TEXT_MAX_LENGTH);
            
            return isLengthValid && isFormatValid;
        }
    }
}
