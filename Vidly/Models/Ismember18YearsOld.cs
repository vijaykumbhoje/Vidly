using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Ismember18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.DateOfBirth == null)
                return new ValidationResult("Birthday is Required.");
            var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;
            return (age >= 18)? ValidationResult.Success : new ValidationResult("Must be 18 years old to get subscription.");
            

            
        }
    }
}