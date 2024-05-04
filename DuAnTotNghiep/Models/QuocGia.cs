using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class QuocGia
    {
        [Key]
        public Guid ID_QuocGia { get; set; }
        public string? TenNuoc { get; set; }

    }
}
