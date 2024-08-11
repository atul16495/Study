using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExamples.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} is not provided")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0}should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage ="{0} Should contains only alphabets space and dots(.)")]
        public string? PersonName {  get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        [EmailAddress(ErrorMessage = "{0} Should be a proper email address")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "{0} Should be 10 digits")]
      //[ValidateNever]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name ="Re-enter Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0,999.99,ErrorMessage = "{0}should be between ${1} and ${2}")]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person object- Person name: {PersonName}, Email:{Email}, Phone: {Phone}, Password: {Password},Confirm Password: {ConfirmPassword}, Price:{Price}";
        }

    }
}
