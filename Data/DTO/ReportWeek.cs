using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.DTO
{
    public class ReportWeek
    {
        public DateOnly Day { get; set; } 
        public int TotalItem { get; set; }
        public int TotalValue { get; set; }
    }
}
