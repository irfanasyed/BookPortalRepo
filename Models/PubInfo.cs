using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boo_Store_Portal_Api.Models
{
    public class PubInfo
    {
        [Key]
        public int? PubId { get; set; }

        public string? Logo { get; set; }

        public string? PrInfo { get; set; }
        [ForeignKey("PubId")]
        public virtual Publisher? Pub { get; set; }
    }
}
