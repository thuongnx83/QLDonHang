using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.DTO
{
    public class ReportDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalItem { get; set; }
        public int TotalValue { get; set; }
    }
}
