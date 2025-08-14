using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.DTO
{
    public class AccountInfo
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
       
        public string FullName { get; set; }
       
        public string? Email { get; set; }
        public bool Active { get; set; }
    }
}
