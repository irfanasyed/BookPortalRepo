using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class CreatePublisherDto
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Publisher Name should be in the range of 5-30")]
        public string? PubName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "City Name should be in the range of 5-30")]

        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Country { get; set; }
    }
}
