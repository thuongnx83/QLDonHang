using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.DTO
{
    public class ReportMonth
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalItem { get; set; }
        public int TotalValue { get; set; }
    }
}
