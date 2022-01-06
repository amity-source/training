using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop_Linq.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Type In Your UserName")]
        //[StringLength(10, ErrorMessage =("Username have to be 10 or more character"))]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please Type In Your Password")]
        //[MaxLength(10, ErrorMessage = ("Password have to be 10 or more character"))]
        public string Password { get; set; }

        public bool RememberMe { get; set; }    
    }
}