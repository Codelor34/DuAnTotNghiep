using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class ThanhToan
    {
        [Key]
        public Guid ID_ThanhToan { get; set; }
        public Guid ID_Gio_Hang_Chi_Tiet {  get; set; }
        public Guid ID_SP_Mua {  get; set; }
        public Guid ID_PhuongThucThanhToan { get; set; }
        public string? Status { get; set; }
        public float? SoTienThanhToan { get; set; }
        public string? DiaChi {  get; set; }
        public string? SDT { get; set; }
        public string? HoTen {  get; set; }
        public Gio_Hang_Chi_Tiet Gio_Hang_Chi_Tiet { get; set; }
        public SanPham_Mua SanPham_Mua { get; set; }
        public PhuongThucThanhToan PhuongThucThanhToan { get; set; }
        public virtual ICollection<Don_Hang_Thanh_Toan> Don_Hang_Thanh_Toan { get; set; }

    }
}
