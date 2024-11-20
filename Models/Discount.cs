using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boo_Store_Portal_Api.Models
{
    public class Discount
    {
        [Key]
        public int DisId { get; set; }
        public string? Dicounttype { get; set; }

        public int? StorId { get; set; }

        public int? Lowqty { get; set; }

        public int? Highqty { get; set; }

        public decimal? Discount1 { get; set; }
        [ForeignKey("StorId")]
        public virtual Store? Stor { get; set; }
    }
}
