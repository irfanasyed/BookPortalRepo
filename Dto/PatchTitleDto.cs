using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class PatchTitleDto
    {
        internal string? Title1;

        [StringLength(100, ErrorMessage = "Title Name cannot exceed 100 characters.")]
        public string? TitleName { get; set; } // Optional field for updating title name

        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string? Type { get; set; } // Optional field for updating type of the book

        [Range(1, int.MaxValue, ErrorMessage = "Publisher ID must be a positive integer.")]
        public int? PublisherId { get; set; } // Optional field for updating publisher ID

        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime? Pubdate { get; set; } // Optional field for updating publish date

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal? Price { get; set; } // Optional field for updating price

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; } // Optional field for additional notes
    }
}

