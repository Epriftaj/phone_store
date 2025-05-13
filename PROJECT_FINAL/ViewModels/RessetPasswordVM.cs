using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJECT_FINAL.ViewModels
{
    public class RessetPasswordVM
    {

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password cannot be empty.")]
        [DisplayName("Password")]
        [MaxLength(100, ErrorMessage = "The Password cannot be longer than 100 characters.")]
        public string Password
        {
            get;
            set;
        }




        [DataType(DataType.Password)]
        [DisplayName("New Password")]
        [MaxLength(100, ErrorMessage = "The Password cannot be longer than 100 characters.")]
        [Compare("Password", ErrorMessage = "The entered passwords do not match.")]
        public string NewPassword
        {
            get;
            set;
        }
    }
}