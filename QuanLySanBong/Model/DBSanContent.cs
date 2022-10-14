using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLySanBong.Model
{
    public partial class DBSanContent : DbContext
    {
        public DBSanContent()
            : base("name=DBSanContent")
        {
        }

        public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBan { get; set; }
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }
        public virtual DbSet<HoaDonBanHang> HoaDonBanHang { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhap { get; set; }
        public virtual DbSet<LoaiSan> LoaiSan { get; set; }
        public virtual DbSet<MatHang> MatHang { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<San> San { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDonBanHang>()
                .Property(e => e.IDSan)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBanHang>()
                .Property(e => e.NguoiBan)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBanHang>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBanHang>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonBanHang>()
                .HasMany(e => e.ChiTietHoaDonBan)
                .WithRequired(e => e.HoaDonBanHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.NhanVienNhap)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDonNhap>()
                .HasMany(e => e.ChiTietHoaDonNhap)
                .WithRequired(e => e.HoaDonNhap)
                .HasForeignKey(e => e.IDHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSan>()
                .HasMany(e => e.San)
                .WithOptional(e => e.LoaiSan)
                .HasForeignKey(e => e.IDLoaiSan);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.TenMatHang)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.ChiTietHoaDonBan)
                .WithRequired(e => e.MatHang)
                .HasForeignKey(e => e.IDMatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.ChiTietHoaDonNhap)
                .WithRequired(e => e.MatHang)
                .HasForeignKey(e => e.IDMatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<San>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<San>()
                .Property(e => e.TenSan)
                .IsUnicode(false);

            modelBuilder.Entity<San>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<San>()
                .Property(e => e.NguoiCapNhat)
                .IsUnicode(false);

            modelBuilder.Entity<San>()
                .HasMany(e => e.HoaDonBanHang)
                .WithOptional(e => e.San)
                .HasForeignKey(e => e.IDSan);
        }
    }
}
