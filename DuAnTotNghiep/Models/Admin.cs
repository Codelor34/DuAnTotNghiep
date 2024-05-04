using DuAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DuAnTotNghiep.Models
{
    public class Admin
    {
        [Key]
        public string? HoTenAdmin { get; set; }
        public string? Sdt { get; set;}
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? UserName { get; set; }
        public User User { get; set; }
    }
}
