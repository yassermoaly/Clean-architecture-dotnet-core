using SharedConfig.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationLayer.Validators
{
    // validate phone like 01152663212
    public class PhoneValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Required validation will be separated
            if (value == null)
                return true;

            ErrorMessage = Errors.E_FORMAT_NOT_VALID;
            bool isValid = Regex.Match(value.ToString(), @"(010|011|012|015)\d{8}$").Success;
            return isValid;
        }
    }
}
