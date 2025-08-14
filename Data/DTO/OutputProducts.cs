using System.ComponentModel.DataAnnotations;

namespace QLDonHangAPI.Data.DTO
{ 
    public class OutputProducts
    {
        public int Id { get; set; }

      
        public string Name { get; set; }

        public int? Price { get; set; }

        public int? Stock { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateModify { get; set; }
      
        public string CreateBy { get; set; }
       
        public string ModifyBy { get; set; }
    }
}
