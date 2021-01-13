using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planny.Models
{
    public class CustomVal : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var sprint = (Sprint) validationContext.ObjectInstance;
            if (DateTime.Compare(DateTime.Now, sprint.StartDate) > 0)
            {
                return new ValidationResult("Start Date cannot be in the past");
            }
            return new ValidationResult("altfel");
        }
    }
}