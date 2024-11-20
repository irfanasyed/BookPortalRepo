using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boo_Store_Portal_Api.Models
{
    public class Sale
    {
        public int? StorId { get; set; }
        [Key]
        public int OrdNum { get; set; }

        public DateTime? OrdDate { get; set; }

        public int? Qty { get; set; }

        public string? Payterms { get; set; }

        public int? TitleId { get; set; }
        [ForeignKey("StorId")]
        public virtual Store? Stor { get; set; }
        [ForeignKey("TitleId")]
        public virtual Title? Title { get; set; }
    }
}
