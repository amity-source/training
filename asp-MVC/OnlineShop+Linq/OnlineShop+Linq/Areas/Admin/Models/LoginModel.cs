using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop_Linq.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Type In Your UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Type In Your Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }    
    }
}