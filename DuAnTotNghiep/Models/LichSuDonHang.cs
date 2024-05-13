using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class LichSuDonHang
    {
        [Key]
        public Guid ID_LichSuDonHang { get; set; }
        public Guid ID_Don_Hoan_Thanh { get; set; }
        public DateTime NgayThang { get; set; }
    }
}
