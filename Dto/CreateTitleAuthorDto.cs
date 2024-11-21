using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class CreateTitleAuthorDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Author ID must be a positive integer.")]
        public int AuthorId { get; set; } // Foreign Key for Author

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Title ID must be a positive integer.")]
        public int TitleId { get; set; } // Foreign Key for Title

        [Required]
        [Range(0, 100, ErrorMessage = "Royalty Percentage must be between 0 and 100.")]
        public decimal RoyaltyPercentage { get; set; } // Royalty percentage for the author
    }
}
