using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DataModels.CustomModels
{
    public class LoginModel
    {
        public string UserKey { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "*Email is Required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "*Password is Required")]
        public string Password { get; set; }
    }
}
