using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class KhuyenMai
    {
        [Key]
        public Guid ID_KhuyenMai { get; set; }
        public string? TruongTrinhKM { get; set; }
        public string? MoTa {  get; set; }
        public string HoTenAdmin { get; set; }
        public Admins Admin { get; set; }
        public virtual ICollection<Gio_Hang_Chi_Tiet> Gio_Hang_Chi_Tiet { get; set; }
        public virtual ICollection<SanPham_Mua> SanPham_Mua { get; set; }
    }
}
