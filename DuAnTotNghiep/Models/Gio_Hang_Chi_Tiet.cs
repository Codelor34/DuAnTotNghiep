using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Gio_Hang_Chi_Tiet
    {
        [Key]
        public Guid ID_Gio_Hang_Chi_Tiet { get; set; }
        public Guid ID_Sp {  get; set; }
        public Guid ID_Km { get; set; }
        public float? SoLuong { get; set; }
        public float? Gia { get; set; }
        public SanPham SanPham { get; set; }
        public KhuyenMai khuyenMai { get; set; }
        public Gio_Hang Gio_Hang { get; set; }
        
    }
}
