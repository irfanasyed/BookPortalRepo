using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boo_Store_Portal_Api.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        public string? Fname { get; set; }

        public string? Minit { get; set; }

        public string? Lname { get; set; }

        public int? JobId { get; set; }

        public string? JobLvl { get; set; }

        public int? PubId { get; set; }

        public DateTime? HireDate { get; set; }
        [ForeignKey("JobId")]
        public virtual Job? Job { get; set; }
        [ForeignKey("PubId")]
        public virtual Publisher? Pub { get; set; }
    }
}
