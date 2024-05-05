using DuAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DuAnTotNghiep.Models
{
    public class Admins
    {
        [Key]
        public string? HoTenAdmin { get; set; }
        public string? Sdt { get; set;}
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? UserName { get; set; }
        public Users Users { get; set; }
        public virtual ICollection<NhanVien> NhanVien { get; set;}
        public virtual ICollection<KhachHang> KhachHang { get; set; }
        public virtual ICollection<KhuyenMai> KhuyenMai { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
