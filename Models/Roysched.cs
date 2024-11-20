using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boo_Store_Portal_Api.Models
{
    public class Roysched
    {
        [Key]
        public int RoyId { get; set; }
        public int? TitleId { get; set; }

        public decimal? Lorange { get; set; }

        public decimal? Hirange { get; set; }

        public decimal? Royalty { get; set; }
        [ForeignKey("TitleId")]
        public virtual Title? Title { get; set; }
    }
}
