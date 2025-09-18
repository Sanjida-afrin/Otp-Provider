using System.ComponentModel.DataAnnotations;
using OtpProvider.WebApi.Entities;

namespace WebApi.Practice.Model
{
  
    public class SendOtpRequest
    {
        // TODO [Task]: Convert to Enum for better validation.
        [Required]
        public required OtpMethod Method { get; set; }

        [Required]
        public required string To { get; set; }

        [Required]
        public required string Otp { get; set; }
    }
}
