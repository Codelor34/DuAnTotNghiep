using DuAnTotNghiep.Models;

namespace DuAnTotNghiep.Models
{
    public class Users
    {      
        public string? UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Admins> Admin { get; set; }
        public virtual ICollection<NhanVien> NhanVien { get; set;}
        public virtual ICollection<User_Khachhang> User_Khachhang { get; set; }
    }
}
