using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class LoaiDt
    {
        [Key]
        public Guid ID_LoaiDt { get; set; }
        public string? TenLoai {  get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
