using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class CreateSaleDto
    {
        [Required]
        public int OrdNum { get; set; }

        [Required]
        public DateTime? OrdDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int? Qty { get; set; }

        [MaxLength(100)]
        public string? Payterms { get; set; }

        [Required]
        public int TitleId { get; set; }

        [Required]
        public int StorId { get; set; }

    }
}
