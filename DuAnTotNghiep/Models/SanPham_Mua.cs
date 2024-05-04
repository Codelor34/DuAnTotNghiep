﻿using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class SanPham_Mua
    {
        [Key]
        public Guid ID_SanPham_Mua { get; set; }
        public Guid ID_Sp {  get; set; }
        public Guid ID_User { get; set; }
        public float? SoLuong { get; set; }
        public float? Gia { get; set; }
        public Guid ID_Km { get; set; }
        public SanPham SanPham { get; set; }
        public KhuyenMai KhuyenMai { get; set; }
        public User_Khachhang User_Khachhang { get; set; }
        public virtual ICollection<ThanhToan> ThanhToan { get; set; }
    }
}
