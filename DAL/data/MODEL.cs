using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.data
{
    public partial class MODEL : DbContext
    {
        public MODEL()
            : base("name=MODEL")
        {
        }

        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
