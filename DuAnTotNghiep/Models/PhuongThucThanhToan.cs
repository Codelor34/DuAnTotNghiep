using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class PhuongThucThanhToan
    {
        [Key]
        public Guid ID_PhuongThucThanhToan { get; set; }
        public string? PhuongThuc {  get; set; }
    }
}
