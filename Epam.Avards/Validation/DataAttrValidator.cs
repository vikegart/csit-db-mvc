using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Avards.Validation
{
    public class DataAttrValidator : ValidationAttribute
    {          
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                if (date.Year > DateTime.Now.Year - 150 && date.Year <= DateTime.Now.Year)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Возраст должен быть не больше 150 лет и не быть отрицательным");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + "");
            }
        }
    }
}