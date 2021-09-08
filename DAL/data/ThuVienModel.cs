using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.data
{
    public partial class ThuVienModel : DbContext
    {
        public ThuVienModel()
            : base("name=ThuVienModel")
        {
        }

        public virtual DbSet<CTPHIEUMUON> CTPHIEUMUONs { get; set; }
        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<PHIEUMUON> PHIEUMUONs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.CTPHIEUMUONs)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTPHIEUMUONs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.THELOAI)
                .WillCascadeOnDelete(false);
        }
    }
}
