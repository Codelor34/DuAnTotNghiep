using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class MauSac
    {
        [Key]
        public Guid ID_MauSac {  get; set; }
        public string? Mausac { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
