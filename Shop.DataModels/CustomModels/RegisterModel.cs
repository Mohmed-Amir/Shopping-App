using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DataModels.CustomModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "*Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Email is Required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "*Password is Required")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
