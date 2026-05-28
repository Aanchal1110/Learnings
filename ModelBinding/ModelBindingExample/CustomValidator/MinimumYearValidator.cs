using System.ComponentModel.DataAnnotations;

namespace ModelBindingExample.CustomValidator
{
    public class MinimumYearValidator:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime date=(DateTime)value;
            if (date.Year <= 2000)
            {
                return new ValidationResult("Minimum year should be greater than 2000");
            }

            else
            {
                return ValidationResult.Success;

            }
        }
    }
}
