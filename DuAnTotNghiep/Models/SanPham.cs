using System.ComponentModel.DataAnnotations;

namespace DuAnTotNghiep.Models
{
    public class SanPham
    {
        [Key]
        public Guid ID_Sp {  get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public string SoLuong { get; set; }
        public double Gia { get; set; }
        public string AnhDaiDien { get; set; }
        public string? DanhGia { get; set; }
        public string? HoTenAdmin { get; set; }
        public Guid? ID_ChatLieu { get; set; }
        public Guid? ID_Hang {  get; set; }
        public Guid? ID_QuocGia { get; set; }
        public Guid? ID_LoaiSp { get; set; }
        public Guid? ID_LoaiDt { get; set; }
        public Guid? ID_MauSac {  get; set; }
        public Guid? ID_KichThuoc { get; set; }
        public ChatLieu ChatLieu { get; set; }
        public HangSX HangSX { get; set; }
        public QuocGia QuocGia { get; set; }
        public LoaiSP LoaiSP { get; set; }
        public LoaiDt LoaiDt { get; set; }
        public MauSac MauSac { get; set; }
        public KichThuoc KichThuoc { get; set; }
    }
}
