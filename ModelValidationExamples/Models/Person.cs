using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationExamples.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExamples.Models
{
    public class Person: IValidatableObject
    {
        [Required(ErrorMessage = "{0} is not provided")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0}should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage ="{0} Should contains only alphabets space and dots(.)")]
       
        
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

        //[MinimumYearValidator(2005, ErrorMessage = "Date of birth should not be newer than {0}")]
       [MinimumYearValidator(2005)]
     //   [BindNever]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate {  get; set; }

        [DateRangeValidator("FormDate", ErrorMessage="'Form Date should be older than or equal to 'To date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<String?>Tages { get; set; } = new List<String>();
        public override string ToString()
        {
            return $"Person object- Person name: {PersonName}, Email:{Email}, Phone: {Phone}, Password: {Password},Confirm Password: {ConfirmPassword}, Price:{Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateOfBirth.HasValue== false && Age.HasValue== false) {

                yield return new ValidationResult("Either date of birth or age should be supplied", new[] {nameof(Age)});
            }
        }
    }
}
