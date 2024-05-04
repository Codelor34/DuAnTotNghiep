using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class DonHang
    {
        [Key]
        public Guid ID_Don_Hang { get; set; }
        public Guid MaNV { get; set; }

    }
}
