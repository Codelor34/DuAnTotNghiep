
using Du_An_Tot_Nghiep.Models;
using DuAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Anh> anh { get; set; }
        public DbSet<AnhSP> anhsp { get; set; }
        public DbSet<ChatLieu> chatLieu { get; set; }
        public DbSet<DanhGia_NhanXet> danhGia_NhanXet { get; set; }
        public DbSet<Don_Hang_Thanh_Toan> don_Hang_Thanh_Toan { get; set; }
        public DbSet<Don_Hoan_Thanh> don_Hoan_Thanh { get; set; }
        public DbSet<DonHang> donHang { get; set; }
        public DbSet<Gio_Hang> gio_Hang { get; set; }
        public DbSet<Gio_Hang_Chi_Tiet> gio_Hang_Chi_Tiet { get; set; }
        public DbSet<HangSX> hangSX { get; set; }
        public DbSet<HoTroKhachHang> hoTroKhachHang { get; set; }
        public DbSet<KhachHang> khachHang { get; set; }
        public DbSet<KhuyenMai> khuyenMai { get; set; }
        public DbSet<KichThuoc> kichThuoc { get; set; }
        public DbSet<LichSuDonHang> lichSuDonHang { get; set; }
        public DbSet<LoaiDt> loaiDt { get; set; }
        public DbSet<LoaiSP> loaiSP { get; set; }
        public DbSet<MauSac> mauSac { get; set; }
        public DbSet<NhanVien> nhanVien { get; set; }
        public DbSet<PhuongThucThanhToan> phuongThucThanhToan { get; set; }
        public DbSet<QuocGia> quocGia { get; set; }
        public DbSet<SanPham> sanPham { get; set; }
        public DbSet<SanPham_Mua> sanPham_Mua { get; set; }
        public DbSet<ThanhToan> thanhToan { get; set; }
        public DbSet<Thongke> thongke { get; set; }
        public DbSet<User_Khachhang> user_Khachhang { get; set; }
        public DbSet<Video> video { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasOne( a => a.User).WithMany().HasForeignKey(a=> a.UserName );

        }
    }

}
