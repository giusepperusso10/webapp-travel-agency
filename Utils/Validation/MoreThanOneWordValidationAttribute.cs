﻿using System.ComponentModel.DataAnnotations;

namespace NetCore_01.Utils.Validation
{
    public class MoreThanOneWordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Trim().Contains(" ") == false)
            {
                return new ValidationResult("Il campo deve contenere almeno due parole");
            }

            return ValidationResult.Success;
        }

    }
}
