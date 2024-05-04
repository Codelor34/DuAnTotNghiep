using System.ComponentModel.DataAnnotations;

namespace Du_An_Tot_Nghiep.Models
{
    public class Thongke
    {
        [Key]
        public Guid ID_ThongKe { get; set; }
        public float? DoanhThu { get; set; }
        public string? KhachHang {  get; set; }
        public string SoLuongTruyCap { get; set; }

    }
}
