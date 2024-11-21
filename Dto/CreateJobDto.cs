using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class CreateJobDto
    {
        [StringLength(50, ErrorMessage = "JobDesc cannot exceed 50 characters")]
        public string? JobDesc { get; set; }



        [StringLength(50, ErrorMessage = "MinLvl cannot exceed 50 characters")]
        public string? MinLvl { get; set; }


        [StringLength(50, ErrorMessage = "MaxLvl cannot exceed 50 characters")]
        public string? MaxLvl { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
