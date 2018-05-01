using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar.Models {
    public class FinishAfterStart : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

            var eventt = (Event)validationContext.ObjectInstance;

            if (eventt.FinishDate < eventt.StartDate)
                return new ValidationResult("Finish date must be after start date.");

            return ValidationResult.Success;
        }

    }
}