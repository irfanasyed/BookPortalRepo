namespace Boo_Store_Portal_Api.Dto
{
    public class ResponseJobDto
    {
        public int JobId { get; set; }

        public string? JobDesc { get; set; }

        public string? MinLvl { get; set; }

        public string? MaxLvl { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
