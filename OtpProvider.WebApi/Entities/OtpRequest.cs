using System.ComponentModel.DataAnnotations;
using WebApi.Practice.Model;

namespace OtpProvider.WebApi.Entities
{
    public class OtpRequest : SendOtpRequest
    {
        [Key]
        public int Id { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime RequestedAt { get; set; }


    }
}
