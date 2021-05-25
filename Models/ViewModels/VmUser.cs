using SharedConfig.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationLayer.Validators;

namespace Models.ViewModels
{
    public class VmUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class VmUserCreate
    {
        [Required(ErrorMessage = Errors.E_NAME_IS_REQUIRED)]
        [NameValidator]
        public string Name { get; set; }

        [Required(ErrorMessage = Errors.E_USERNAME_IS_REQUIRED)]
        [UsernameValidator]
        public string Username { get; set; }

        [Required(ErrorMessage = Errors.E_PASSWORD_IS_REQUIRED)]
        [PasswordValidator]
        public string Password { get; set; }
    }
}
