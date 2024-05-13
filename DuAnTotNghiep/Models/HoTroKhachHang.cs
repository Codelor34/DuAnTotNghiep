using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class HoTroKhachHang
    {
        [Key]
        public Guid ID_HoTroKhachHang { get; set; }
        public Guid MaNV {  get; set; }
        public Guid ID_User { get; set; }
        public string? LoaiHT { get; set; }
        public string? PTLienLac { get; set; }

    }
}
