using DuAnTotNghiep.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DuAnTotNghiep.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Admins> Admins { get; set; }
    public DbSet<Anh> Anh { get; set; }
    public DbSet<AnhSP> AnhSP { get; set; }
    public DbSet<ChatLieu> ChatLieu { get; set; }
    public DbSet<DanhGia_NhanXet> DanhGia_NhanXet { get; set; }
    public DbSet<Don_Hang_Thanh_Toan> Don_Hang_Thanh_Toan { get; set; }
    public DbSet<Don_Hoan_Thanh> Don_Hoan_Thanh { get; set; }
    public DbSet<DonHang> DonHang { get; set; }
    public DbSet<Gio_Hang> Gio_Hang { get; set; }
    public DbSet<Gio_Hang_Chi_Tiet> Gio_Hang_Chi_Tiet { get; set; }
    public DbSet<HangSX> HangSX { get; set; }
    public DbSet<HoTroKhachHang> HoTroKhachHang { get; set; }
    public DbSet<KhachHang> KhachHang { get; set; }
    public DbSet<KhuyenMai> KhuyenMai { get; set; }
    public DbSet<KichThuoc> KichThuoc { get; set; }
    public DbSet<LichSuDonHang> LichSuDonHang { get; set; }
    public DbSet<LoaiDt> LoaiDt { get; set; }
    public DbSet<LoaiSP> LoaiSP { get; set; }
    public DbSet<MauSac> MauSac { get; set; }
    public DbSet<NhanVien> NhanVien { get; set; }
    public DbSet<PhuongThucThanhToan> PhuongThucThanhToan { get; set; }
    public DbSet<QuocGia> QuocGia { get; set; }
    public DbSet<SanPham> SanPham { get; set; }
    public DbSet<SanPham_Mua> SanPham_Mua { get; set; }
    public DbSet<ThanhToan> ThanhToan { get; set; }
    public DbSet<Thongke> Thongke { get; set; }
    public DbSet<User_Khachhang> User_Khachhang { get; set; }
    public DbSet<Video> Video { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Admins>().HasOne(a => a.Users).WithMany().HasForeignKey(a => a.UserName);
        builder.Entity<KhachHang>().HasOne(a => a.Admins).WithMany().HasForeignKey(a => a.HoTenAdmin);
        builder.Entity<User_Khachhang>().HasOne(a => a.Users).WithMany().HasForeignKey(a => a.UserName);
        builder.Entity<User_Khachhang>().HasOne(a => a.KhachHang).WithMany().HasForeignKey(a => a.Hoten);
        builder.Entity<KhuyenMai>().HasOne(a => a.Admins).WithMany().HasForeignKey(a => a.HoTenAdmin);
        builder.Entity<SanPham>().HasOne(a => a.ChatLieu).WithMany().HasForeignKey(a => a.ID_ChatLieu);
        builder.Entity<SanPham>().HasOne(a => a.HangSX).WithMany().HasForeignKey(a => a.ID_Hang);
        builder.Entity<SanPham>().HasOne(a => a.QuocGia).WithMany().HasForeignKey(a => a.ID_QuocGia);
        builder.Entity<SanPham>().HasOne(a => a.LoaiSP).WithMany().HasForeignKey(a => a.ID_LoaiSp);
        builder.Entity<SanPham>().HasOne(a => a.LoaiDt).WithMany().HasForeignKey(a => a.ID_LoaiDt);
        builder.Entity<SanPham>().HasOne(a => a.MauSac).WithMany().HasForeignKey(a => a.ID_MauSac);
        builder.Entity<SanPham>().HasOne(a => a.KichThuoc).WithMany().HasForeignKey(a => a.ID_KichThuoc);
        builder.Entity<NhanVien>().HasOne(a => a.Users).WithMany().HasForeignKey(a => a.UserName);
        builder.Entity<NhanVien>().HasOne(a => a.Admins).WithMany().HasForeignKey(a => a.HoTenAdmin);
    }
}

