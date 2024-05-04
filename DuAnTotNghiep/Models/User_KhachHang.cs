using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class User_Khachhang
    {
        [Key]
        public Guid ID_User { get; set; }
        public string? Hoten { get; set; }
        public string? UserName { get; set; }
        public KhachHang KhachHang { get; set; }
        public Users User { get; set; } 
        public virtual ICollection<Gio_Hang> Gio_Hang { get; set;}
        public virtual ICollection<SanPham_Mua> SanPham_Mua { get; set; }
        public virtual ICollection<HoTroKhachHang> HoTroKhachHang { get; set; }


    }
}
