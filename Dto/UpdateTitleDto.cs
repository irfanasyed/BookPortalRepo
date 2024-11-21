using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class UpdateTitleDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Publisher ID must be a positive integer.")]
        public int PublisherId { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [CustomValidation(typeof(UpdateTitleDto), nameof(ValidatePublishDate))]
        public DateTime PublishDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }

        // Custom validation to ensure PublishDate is not in the future
        public static ValidationResult ValidatePublishDate(DateTime publishDate, ValidationContext context)
        {
            if (publishDate > DateTime.Now)
            {
                return new ValidationResult("Publish Date cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}

