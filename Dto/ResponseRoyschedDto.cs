using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class ResponseRoyschedDto
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the Roysched

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Title ID must be a positive integer.")]
        public int TitleId { get; set; } // Foreign Key for Title

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Low Range must be a non-negative number.")]
        public decimal LowRange { get; set; } // Minimum range for royalty

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "High Range must be greater than zero.")]
        public decimal HighRange { get; set; } // Maximum range for royalty

        [Required]
        [Range(0.01, 100.00, ErrorMessage = "Royalty percentage must be between 0.01 and 100.")]
        public decimal Royalty { get; set; } // Royalty percentage
    }
}

