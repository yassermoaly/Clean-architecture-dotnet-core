using SharedConfig.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationLayer.Validators
{
    // validate URL for images' URL and socail accounts' URL
    public class URLValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_FORMAT_NOT_VALID;
            bool isValid = Regex.Match(value.ToString(), @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$").Success;
            return isValid;
        }
    }
}
