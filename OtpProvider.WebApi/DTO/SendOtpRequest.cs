using System.ComponentModel.DataAnnotations;

namespace WebApi.Practice.Model
{
    public class SendOtpRequest
    {
        // TODO [Task]: Convert to Enum for better validation.
        [Required]
        public required string Method { get; set; }

        [Required]
        public required string To { get; set; }

        [Required]
        public required string Otp { get; set; }
    }
}
