using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Gio_Hang
    {
        [Key]
        public Guid ID_Gio_Hang { get; set; }
        public Guid ID_User { get; set; }
        public User_Khachhang User_Khachhang { get; set; }
        public virtual ICollection<Gio_Hang_Chi_Tiet> Gio_Hang_Chi_Tiet { get; set; }
    }
}
