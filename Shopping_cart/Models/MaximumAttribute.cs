using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Shopping_cart.Models
{
    public class MaximumAttribute : ValidationAttribute
    {

        public string msg(string msg)
        {
            return " بالتكت بتاعها";
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            if ((double)value > 1000)
            {
                return new ValidationResult(" كتير عليك");
            }
            else
            return ValidationResult.Success;
        }
    }
}
