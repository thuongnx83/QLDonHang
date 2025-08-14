using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.Entities
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string  Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateModify { get; set; }
        [StringLength(250)]
        public string CreateBy { get; set; }
        [StringLength(250)]
        public string ModifyBy { get; set; }
    }
}
