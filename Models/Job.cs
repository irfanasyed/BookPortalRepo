using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        public string? JobDesc { get; set; }

        public string? MinLvl { get; set; }

        public string? MaxLvl { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

