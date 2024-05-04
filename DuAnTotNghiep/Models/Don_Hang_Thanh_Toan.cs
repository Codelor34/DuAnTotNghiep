using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Don_Hang_Thanh_Toan
    {
        [Key]
        public Guid ID_Don_Hang_Thanh_Toan { get; set; }
        public Guid ID_ThanhToan { get; set; }
        public Guid ID_Don_Hang { get; set; }
        public string? Status { get; set; }
        public DateTime NgayTT { get; set; }
        public string? KieuTT { get; set; }
        public ThanhToan ThanhToan { get; set; }
        public DonHang DonHang { get; set; }
        public Don_Hoan_Thanh Don_Hoan_Thanh { get; set; }
    }
}
