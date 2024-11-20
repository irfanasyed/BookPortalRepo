using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Models
{
    public class Author
    {
        [Key]
        public int AuId { get; set; }

        public string? AuLname { get; set; }

        public string? AuFname { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        public string? Contract { get; set; }
    }
}
