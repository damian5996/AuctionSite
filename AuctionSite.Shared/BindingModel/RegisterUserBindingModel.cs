using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuctionSite.Shared.BindingModel
{
    public class RegisterUserBindingModel
    {
        [EmailAddress]
        [Required()]
        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(128)]
        [Required()]
        public string FirstName { get; set; }
        [StringLength(128)]
        [Required()]
        public string LastName { get; set; }
        [StringLength(128)]
        public string MiddleNames { get; set; }
        public DateTime BirthDate { get; set; }
        [Required()]
        public string Username { get; set; }
        [RegularExpression(Constants.BindingModelValidation.PasswordRegex, ErrorMessage = Constants.Error.PasswordNotComplex)]
        [Required()]
        public string Password { get; set; }
        [Compare("Password")]
        [Required()]
        public string ConfirmPassword { get; set; }
        [Required()]
        [RegularExpression(Constants.BindingModelValidation.PhoneNumberRegex, ErrorMessage = Constants.Error.PhoneNumberIncorrectFormat)]
        public string PhoneNumber { get; set; }
    }
}
