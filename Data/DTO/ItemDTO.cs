using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.DTO
{
    public class ItemDTO
    {
        public int ProductId { get; set; }

        public int Total { get; set; }
       
        public int Price { get; set; }
        
        public int TotalPrice { get; set; }
    }
}
