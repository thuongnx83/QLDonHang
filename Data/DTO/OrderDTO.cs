using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
         
        public DateTime? DateCreate { get; set; }
        public List<ItemDTO>? Items { get; set; }
    }
}
