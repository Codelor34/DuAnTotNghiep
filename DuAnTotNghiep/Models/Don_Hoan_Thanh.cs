using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Don_Hoan_Thanh
    {
        [Key]
        public Guid ID_Don_Hoan_Thanh { get; set; }
        public Guid ID_Don_Hang_Thanh_Toan { get; set; }
        public virtual ICollection<LichSuDonHang> LichSuDonHang { get; set; }
        public virtual ICollection<DanhGia_NhanXet> DanhGia_NhanXets { get; set; }
    }
}
