using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OZ_HEPSIBURADA.WEBUI.Models.AccountVM
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter your username!")]
        [MaxLength(50, ErrorMessage = "User name can not be longer than 50 characters!")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your name and surname!")]
        [Display(Name = "Name & Surname")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail!")]
        [EmailAddress(ErrorMessage = "E-mail address is not valid!")]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a delivery address!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password!")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your phone number!")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your delivery address!")]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "Please enter your invoice address!")]
        [Display(Name = "Invoice Address")]
        public string InvoiceAddress { get; set; }
    }
}