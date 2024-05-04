using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class ChatLieu
    {
        [Key]
        public Guid ID_ChatLieu { get; set; }
        public string? Chatlieu { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
