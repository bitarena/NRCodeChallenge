using NRCodeChallenge.WebApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NRCodeChallenge.WebApi.Attributes
{
    public class TakeValidate : ValidationAttribute
    {
        private IEnumerable<int> correctTakes = new List<int> { 50, 100, 150 };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as ContributorRequest;
            var requestTake = model.Take;

            if (!correctTakes.Contains(requestTake))
            {
                return new ValidationResult("Only values 50, 100 and 150 are allowed");
            }

            return ValidationResult.Success;
        }
    }
}
