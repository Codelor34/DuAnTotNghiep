using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class KichThuoc
    {
        [Key]
        public Guid ID_KichThuoc { get; set; }
        public string? Kichthuoc {  get; set; }

    }
}
