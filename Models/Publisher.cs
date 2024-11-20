using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Models
{
    public class Publisher
    {
        [Key]
        public int PubId { get; set; }

        public string? PubName { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
