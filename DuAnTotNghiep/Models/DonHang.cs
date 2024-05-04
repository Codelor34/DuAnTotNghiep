using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class DonHang
    {
        [Key]
        public Guid ID_Don_Hang { get; set; }
        public Guid MaNV { get; set; }
        public NhanVien NhanVien { get; set; }
        public virtual ICollection<Don_Hang_Thanh_Toan> Don_Hang_Thanh_Toan { get; set; }
    }
}
