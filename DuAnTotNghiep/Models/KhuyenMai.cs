﻿using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class KhuyenMai
    {
        [Key]
        public Guid ID_Km { get; set; }
        public string TruongTrinhKM { get; set; }
        public string MoTa {  get; set; }
        public string? HoTenAdmin { get; set; }
        public Admins Admins { get; set; }
    }
}
