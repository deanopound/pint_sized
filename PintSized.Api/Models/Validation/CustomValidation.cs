using System;
using System.ComponentModel.DataAnnotations;

namespace PintSized.Api.Models.Validation
{
    public class CustomValidation
    {
        public sealed class CheckUrlValid : ValidationAttribute
        {
            protected override ValidationResult IsValid(object Url, ValidationContext validationContext)
            {
                Uri uriResult;

                bool result = Uri.TryCreate(Url.ToString(), UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (result)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Invalid url.");
                }
            }
        }
    }
}