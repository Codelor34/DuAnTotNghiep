using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class AnhSP
    {
        [Key]
        public Guid ID_AnhSp { get; set; }
        public string? FileAnh {  get; set; }
        public Guid ID_Sp { get; set; }
        public  SanPham SanPham { get; set; }
    }
}
