using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class Video
    {
        [Key]
        public Guid ID_Video { get; set; }
        public Guid ID_DanhGia_NhanXet { get; set; }
        public string? video {  get; set; }
    }
}
