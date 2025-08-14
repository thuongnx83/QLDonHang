using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.Entities
{
    public class Accounts
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(250)]
        public string FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool Active { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public DateTime? LastLogin { get; set; }
        [StringLength(250)]
        public string CreateBy { get; set; }
        [StringLength(250)]
        public string ModifyBy { get; set; }
    }
}