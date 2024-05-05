
using DuAnTotNghiep.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DuAnTotNghiep.Data
{
    public class ApplicationDbContext : DbContext
    {

    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Anh> Anh { get; set; }
        public DbSet<AnhSP> Anhsp { get; set; }
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
        public DbSet<NhanVien> nhanVien { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToan { get; set; }
        public DbSet<QuocGia> QuocGia { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<SanPham_Mua> SanPham_Mua { get; set; }
        public DbSet<ThanhToan> ThanhToan { get; set; }
        public DbSet<Thongke> Thongke { get; set; }
        public DbSet<User_Khachhang> User_Khachhang { get; set; }
        public DbSet<Video> Video { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
        .HasKey(u => u.UserName);
            modelBuilder.Entity<Admins>().HasOne( a => a.Users).WithMany().HasForeignKey(a=> a.UserName );
            modelBuilder.Entity<NhanVien>().HasOne(nv => nv.Users).WithOne().HasForeignKey<NhanVien>(nv => nv.UserName);
            modelBuilder.Entity<NhanVien>().HasOne(a => a.Admin).WithMany().HasForeignKey(a => a.HoTenAdmin);
            modelBuilder.Entity<KhachHang>().HasOne(a => a.Admins).WithMany().HasForeignKey(a =>a.HoTenAdmin);
            modelBuilder.Entity<User_Khachhang>().HasOne(a => a.KhachHang).WithOne().HasForeignKey<User_Khachhang>(a => a.Hoten);
            modelBuilder.Entity<User_Khachhang>().HasOne(a => a.Users).WithOne().HasForeignKey<User_Khachhang>(a => a.UserName);
            modelBuilder.Entity<KhuyenMai>().HasOne(a => a.Admins).WithMany().HasForeignKey(a => a.HoTenAdmin);
            modelBuilder.Entity<SanPham>().HasOne(a => a.Admin).WithMany().HasForeignKey(a => a.HoTenAdmin);
            modelBuilder.Entity<SanPham>().HasOne(a => a.ChatLieu).WithMany().HasForeignKey(a => a.ID_ChatLieu);//
            modelBuilder.Entity<SanPham>().HasOne(a => a.HangSX).WithMany().HasForeignKey(a => a.ID_Hang);//
            modelBuilder.Entity<SanPham>().HasOne(a => a.QuocGia).WithMany().HasForeignKey(a=>a.ID_QuocGia);//
            modelBuilder.Entity<SanPham>().HasOne(a => a.LoaiSP).WithMany().HasForeignKey(a => a.ID_LoaiSp);//
            modelBuilder.Entity<SanPham>().HasOne(a => a.LoaiDt).WithMany().HasForeignKey(a => a.ID_LoaiDt);//
            modelBuilder.Entity<SanPham>().HasOne(a => a.MauSac).WithMany().HasForeignKey(a => a.ID_MauSac);//
            modelBuilder.Entity<SanPham>().HasOne(a => a.KichThuoc).WithMany().HasForeignKey(a => a.ID_KichThuoc);//
            modelBuilder.Entity<AnhSP>().HasOne(a => a.SanPham).WithMany().HasForeignKey(a => a.ID_Sp);
            modelBuilder.Entity<Gio_Hang>().HasOne(a => a.User_Khachhang).WithMany().HasForeignKey(a => a.ID_User);
            modelBuilder.Entity<Gio_Hang_Chi_Tiet>().HasOne(a => a.SanPham).WithMany().HasForeignKey(a => a.ID_Sp);//
           // modelBuilder.Entity<Gio_Hang_Chi_Tiet>().HasOne(a => a.Gio_Hang).WithMany().HasForeignKey(a => a.ID_Gio_Hang);//
            modelBuilder.Entity<Gio_Hang_Chi_Tiet>().HasOne(a => a.khuyenMai).WithMany().HasForeignKey(a => a.ID_Km);
            modelBuilder.Entity<SanPham_Mua>().HasOne(a => a.SanPham).WithMany().HasForeignKey(a => a.ID_Sp);
            modelBuilder.Entity<SanPham_Mua>().HasOne(a => a.KhuyenMai).WithMany().HasForeignKey(a => a.ID_Km);
            modelBuilder.Entity<SanPham_Mua>().HasOne(a => a.User_Khachhang).WithMany().HasForeignKey(a => a.ID_User);
            modelBuilder.Entity<ThanhToan>().HasOne(a => a.Gio_Hang_Chi_Tiet).WithMany().HasForeignKey(a => a.ID_Gio_Hang_Chi_Tiet);
            modelBuilder.Entity<ThanhToan>().HasOne(a => a.SanPham_Mua).WithMany().HasForeignKey(a => a.ID_SP_Mua);
            modelBuilder.Entity<ThanhToan>().HasOne(a => a.PhuongThucThanhToan).WithMany().HasForeignKey(a => a.ID_PhuongThucThanhToan);
            modelBuilder.Entity<DonHang>().HasOne(a => a.NhanVien).WithMany().HasForeignKey(a => a.ID_Don_Hang);
            modelBuilder.Entity<Don_Hang_Thanh_Toan>().HasOne(a => a.ThanhToan).WithMany().HasForeignKey(a => a.ID_ThanhToan);
            modelBuilder.Entity<Don_Hang_Thanh_Toan>().HasOne(a => a.DonHang).WithMany().HasForeignKey(a => a.ID_Don_Hang);
            modelBuilder.Entity<LichSuDonHang>().HasOne(a => a.Don_Hoan_Thanh_).WithMany().HasForeignKey(a => a.ID_Don_Hoan_Thanh);
            modelBuilder.Entity<DanhGia_NhanXet>().HasOne(a => a.Don_Hoan_Thanh).WithMany().HasForeignKey(a => a.ID_Don_Hoan_Thanh);
            modelBuilder.Entity<Anh>().HasOne(a => a.DanhGia_NhanXet).WithMany().HasForeignKey(a => a.ID_DanhGia_NhanXet);
            modelBuilder.Entity<Video>().HasOne(a => a.DanhGia_NhanXet).WithMany().HasForeignKey(a => a.ID_DanhGia_NhanXet);
            modelBuilder.Entity<HoTroKhachHang>().HasOne(a => a.NhanVien).WithMany().HasForeignKey(a => a.MaNV);
            modelBuilder.Entity<HoTroKhachHang>().HasOne(a => a.User_Khachhang).WithMany().HasForeignKey(a => a.ID_User);
           
        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ES0LE9K;Initial Catalog=Du_an_tott_nghiep;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        

    }
    

}
