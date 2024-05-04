using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class User_Khachhang
    {
        [Key]
        public Guid ID_User { get; set; }
        public string? Hoten { get; set; }
        public string? UserName { get; set; }

    }
}
