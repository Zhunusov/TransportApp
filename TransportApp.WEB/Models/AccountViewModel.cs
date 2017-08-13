using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.WEB.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType =typeof(Resources.Resource),
            ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "EmailValidation")]
        [Display(Name = "EmailDisplay", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource), 
            ErrorMessageResourceName = "PasswordValidation", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "PasswordDisplay", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPasswordDisplay", ResourceType = typeof(Resources.Resource))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "ConfirmPasswordCompare")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "EmailRequired")]
        [Display(Name = "EmailDisplay", ResourceType = typeof(Resources.Resource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "EmailValidation")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "PasswordDisplay", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Display(Name = "RememberMeDisplay", ResourceType = typeof(Resources.Resource))]
        public bool RememberMe { get; set; }
    }
}