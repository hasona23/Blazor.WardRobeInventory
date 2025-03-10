using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WardrobeInventory.hasona23.Models
{
    public class ColorValidationAttribute : ValidationAttribute
    {
        public string ErrorMessage => "Not Valid Color. Format must be #RRGGBB";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string color)
            {
                if (!string.IsNullOrEmpty(color) && Regex.IsMatch(color, "[0-9A-Fa-f]{6}|0"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult($"Invalid: {ErrorMessage}");
        }
    }
}
