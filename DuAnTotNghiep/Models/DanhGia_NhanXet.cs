using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class DanhGia_NhanXet
    {
        [Key]
        public Guid ID_DanhGia_NhanXet { get; set; }
        public Guid ID_Don_Hoan_Thanh { get; set; }
        public string? HoTen {  get; set; }
        public string? NoiDung {  get; set; }
        public DateTime Ngay { get; set; }
        public Don_Hoan_Thanh Don_Hoan_Thanh { get; set; }
        public virtual ICollection<Anh> Anh { get; set; }
        public virtual ICollection<Video> Video { get; set; }
    }
}
