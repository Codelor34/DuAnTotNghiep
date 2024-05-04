using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Anh
    {
        [Key]
        public Guid? ID_Anh { get; set; }
        public Guid? ID_DanhGia_NhanXet { get; set; }
        public string? HinhAnh {  get; set; }
        public DanhGia_NhanXet DanhGia_NhanXet { get; set; }
    }
}
