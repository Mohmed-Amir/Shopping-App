using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DataModels.CustomModels
{
    public class PasswordModel
    {
        public int UserKey { get; set; }

        [Required(ErrorMessage = "*Old Password is Required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "*Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Confirm Password is Required")]
        public string ConfirmPassword { get; set; }
    }
}
