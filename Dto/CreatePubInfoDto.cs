using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class CreatePubInfoDto
    {
        [Required]
        public string? Logo { get; set; }

        [Required]
        public string? PrInfo { get; set; }
    }
}
