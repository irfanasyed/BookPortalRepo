using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class ResponseTitleDto
    {
        [Required]
        public int Id { get; set; } // Unique identifier for the title

        [Required]
        [StringLength(100, ErrorMessage = "Title Name cannot exceed 100 characters.")]
        public string Name { get; set; } // Title name

        [Required]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; } // Type of the book (e.g., Technical, Fiction)

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Publisher ID must be a positive integer.")]
        public int PublisherId { get; set; } // ID of the publisher

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime PublishDate { get; set; } // Date when the title was published

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; } // Price of the book
    }
}

