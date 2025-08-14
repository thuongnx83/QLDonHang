using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TotalItem { get; set; }
        [Required]
        public long TotalPrice { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateModify { get; set; } 
    }
}
