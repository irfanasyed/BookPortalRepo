using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class CreateTitleDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Type name cannot exceed 50 characters")]
        public string Type { get; set; }

        //[Required]
        //[StringLength(100,ErrorMessage ="Publisher ID must be the positive integer")]
        //public string PublisherId { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        //[CustomValidation(typeof(CreateTitleDto), nameof(ValidatePublishDate))]
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

