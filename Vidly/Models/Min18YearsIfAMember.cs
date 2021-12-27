using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (Customer)validationContext.ObjectInstance;
            if (Customer.MemberShipTypeId==0 || Customer.MemberShipTypeId == 1)
                return ValidationResult.Success;

            if (Customer.DOB == null)
                return new ValidationResult("Enter the DOB please !");

            var age = DateTime.Now.Year - Customer.DOB.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("should be at least 18 years old.");
        }
    }
}