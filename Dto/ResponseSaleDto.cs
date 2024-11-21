using System.ComponentModel.DataAnnotations;

namespace Boo_Store_Portal_Api.Dto
{
    public class ResponseSaleDto
    {
        public int? StorId { get; set; }
        public int OrdNum { get; set; }
        public DateTime? OrdDate { get; set; }
        public int? Qty { get; set; }

        [MaxLength(100)]
        public string? Payterms { get; set; }

        public int? TitleId { get; set; }

        public ResponseStoreDto? Stor { get; set; }
        public ResponseTitleDto? Title { get; set; }
    }
}
