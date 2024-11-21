using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class PutTitleDto
    {
        [Required(ErrorMessage = "Title ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Title ID must be a positive integer.")]
        public int Id { get; set; } // Required for identifying the title to update

        [Required(ErrorMessage = "Title Name is required.")]
        [StringLength(100, ErrorMessage = "Title Name cannot exceed 100 characters.")]
        public string Name { get; set; } // Title name

        [Required(ErrorMessage = "Type is required.")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; } // Type of the book (e.g., Technical, Fiction)

        [Required(ErrorMessage = "Publisher ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Publisher ID must be a positive integer.")]
        public int PublisherId { get; set; } // ID of the publisher

        [Required(ErrorMessage = "Publish Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime PublishDate { get; set; } // Date when the title was published

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; } // Price of the book
    }
}

