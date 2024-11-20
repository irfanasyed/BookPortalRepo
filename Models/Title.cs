using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boo_Store_Portal_Api.Models
{
    public class Title
    {
        [Key]
        public int TitleId { get; set; }

        public string? Title1 { get; set; }

        public string? Type { get; set; }

        public int? PubId { get; set; }

        public decimal? Price { get; set; }

        public decimal? Advance { get; set; }

        public decimal? Royalty { get; set; }

        public decimal? YtdSales { get; set; }

        public string? Notes { get; set; }

        public DateTime? Pubdate { get; set; }
        [ForeignKey("PubId")]
        public virtual Publisher? Pub { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
