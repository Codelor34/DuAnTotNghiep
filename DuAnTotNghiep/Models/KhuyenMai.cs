using System.ComponentModel.DataAnnotations;

namespace Du_An_Tot_Nghiep.Models
{
    public class KhuyenMai
    {
        [Key]
        public Guid ID_KhuyenMai { get; set; }
        public string? TruongTrinhKM { get; set; }
        public string? MoTa {  get; set; }
        public string HoTenAdmin { get; set; }
    }
}
