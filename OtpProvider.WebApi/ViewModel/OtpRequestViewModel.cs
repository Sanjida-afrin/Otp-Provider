namespace OtpProvider.WebApi.ViewModel
{
    public class OtpRequestViewModel
    {
        public int Id { get; set; }

        public required string Method { get; set; }

        public required string To { get; set; }

        public required string Otp { get; set; }
    }
}
