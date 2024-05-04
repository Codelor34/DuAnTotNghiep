using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class HangSX
    {
        [Key]
        public Guid ID_Hang {  get; set; }
        public string? HangSx { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
