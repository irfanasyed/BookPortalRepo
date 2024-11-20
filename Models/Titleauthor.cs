using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boo_Store_Portal_Api.Models
{
    public class Titleauthor
    {
        [Key]
        public int TitleAuId { get; set; }
        public int? AuId { get; set; }

        public int? TitleId { get; set; }

        public string? AuOrd { get; set; }

        public string? Royaltyper { get; set; }
        [ForeignKey("AuId")]
        public virtual Author? Au { get; set; }
        [ForeignKey("TitleId")]
        public virtual Title? Title
        {
            get; set;
        }
        }
}
