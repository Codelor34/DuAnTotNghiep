using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class NhanVien
    {
        [Key]
        public Guid MaNV { get; set; }
        public string? HoTenNV { get; set; }
        public string? HoTenAdmin { get; set; }
        public string ? Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? UserName { get; set; }
        public Users Users { get; set; }
        public Admin Admin { get; set; }
        public virtual ICollection<DonHang> DonHang { get; set; }
        public virtual ICollection<HoTroKhachHang> HoTroKhachHang { get; set; }

    }
}
