using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityFramework_MVC.Models
{
    public partial class QuanLiNhanVienContext : DbContext
    {
        public QuanLiNhanVienContext()
        {
        }

        public QuanLiNhanVienContext(DbContextOptions<QuanLiNhanVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoaiNhanVien> LoaiNhanViens { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-G9HMKMUF;Initial Catalog=QuanLiNhanVien;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LoaiNhanVien>(entity =>
            {
                entity.HasKey(e => e.IdNv_145)
                    .HasName("PK__loaiNhan__9DB8797C880ED4F2");

                entity.ToTable("loaiNhanVien");

                entity.Property(e => e.IdNv_145).HasColumnName("idNv");

                entity.Property(e => e.LoaiNv_145)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("loaiNv");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => new { e.MaNv_145 })
                    .HasName("PK__nhanVien__DA1B95036BC5C7B0");

                entity.ToTable("nhanVien");

                entity.Property(e => e.IdNv_145).HasColumnName("idNv");

                entity.Property(e => e.MaNv_145)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("maNv");

                entity.Property(e => e.GioiTinh_145)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("gioiTinh");

                entity.Property(e => e.HeSoLuong_145).HasColumnName("heSoLuong");

                entity.Property(e => e.NgaySinh_145)
                    .HasColumnType("date")
                    .HasColumnName("ngaySinh");

                entity.Property(e => e.NgayVaoCoQuan_145)
                    .HasColumnType("date")
                    .HasColumnName("ngayVaoCoQuan");

                entity.Property(e => e.SoCmnd_145)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("soCMND");

                entity.Property(e => e.TenNv_145)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("tenNV");

                entity.HasOne(d => d.IdNvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdNv_145)
                    .HasConstraintName("FK_idNv_nhanVien");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
