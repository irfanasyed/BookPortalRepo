using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class CreateStoreDto
    {
        [Required(ErrorMessage = "Store name is required.")]
        [StringLength(100, ErrorMessage = "Store name can't exceed 100 characters.")]
        public string? StorName { get; set; }

        [Required(ErrorMessage = "Store address is required.")]
        [StringLength(255, ErrorMessage = "Address can't exceed 255 characters.")]
        public string? StorAddress { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City can't exceed 100 characters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State can't exceed 50 characters.")]
        public string? State { get; set; }
        [Required]
        [RegularExpression(@"^\d{6}(-\d{4})?$", ErrorMessage = "Invalid Zip code format. Please use either '12345' or '12345-6789'.")]
        public string? Zip { get; set; }
    }
}
