using SharedConfig.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationLayer.Validators;

namespace Models.ViewModels
{
    public class VmLoginRequest
    {
        [Required(ErrorMessage = Errors.E_USERNAME_IS_REQUIRED)]
        [NameValidator]
        public string UserName { get; set; }
        [Required(ErrorMessage = Errors.E_PASSWORD_IS_REQUIRED)]
        public string Password { get; set; }
    }

    public class VmLoginResponse
    {
        public string Token { get; set; }
    }
}
