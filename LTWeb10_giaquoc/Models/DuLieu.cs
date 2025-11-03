using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LTWeb10_giaquoc.Models
{
    public partial class DuLieu : DbContext
    {
        public DuLieu()
            : base("name=DuLieu")
        {
        }

        public virtual DbSet<chitietdonhang> chitietdonhangs { get; set; }
        public virtual DbSet<chude> chudes { get; set; }
        public virtual DbSet<donhang> donhangs { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<nhaxuatban> nhaxuatbans { get; set; }
        public virtual DbSet<sach> saches { get; set; }
        public virtual DbSet<tacgia> tacgias { get; set; }
        public virtual DbSet<thamgia> thamgias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<chitietdonhang>()
                .Property(e => e.dongia)
                .HasPrecision(20, 2);

            modelBuilder.Entity<donhang>()
                .HasMany(e => e.chitietdonhangs)
                .WithRequired(e => e.donhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .HasOptional(e => e.donhang)
                .WithRequired(e => e.khachhang);

            modelBuilder.Entity<nhaxuatban>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .Property(e => e.giaban)
                .HasPrecision(20, 2);

            modelBuilder.Entity<sach>()
                .Property(e => e.anhbia)
                .IsUnicode(false);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.chitietdonhangs)
                .WithRequired(e => e.sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sach>()
                .HasMany(e => e.thamgias)
                .WithRequired(e => e.sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tacgia>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<tacgia>()
                .HasMany(e => e.thamgias)
                .WithRequired(e => e.tacgia)
                .WillCascadeOnDelete(false);
        }
    }
}
