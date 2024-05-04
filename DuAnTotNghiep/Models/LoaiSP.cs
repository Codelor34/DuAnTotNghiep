using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class LoaiSP
    {
        [Key]
        public Guid ID_LoaiSp { get; set; }
        public string? Loai {  get; set; }

    }
}
