using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateModify { get; set; }
    }
}
