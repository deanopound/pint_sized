using System;
using System.ComponentModel.DataAnnotations;
using static PintSized.Api.Models.Validation.CustomValidation;

namespace PintSized.Api.Models.Request
{
    public class ShortURLRequest
    {
        [Required]
        [CheckUrlValid(ErrorMessage = "Please enter a valid Url")]
        public string LongURL { get; set; }

        public DateTime CreatedAt
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}