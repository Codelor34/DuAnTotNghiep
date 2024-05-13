using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DuAnTotNghiep.Models
{
    public class KhachHang

    {
        [Key]
        public string HoTen {  get; set; }
        public string Sdt { get; set;}
        public string? Email { get; set;}
        public string? DiaChi { get; set;}
        public DateTime? NgaySinh { get; set;}
        public string? HoTenAdmin { get; set;}
        public Admins Admins { get; set; }
    }
}
