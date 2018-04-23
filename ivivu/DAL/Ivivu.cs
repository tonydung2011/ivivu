using System;
using ivivu.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ivivu.DAL
{
    public class IvivuContext : DbContext
    {
        public IvivuContext() : base("name=QLKS")
        {            
        }
        public DbSet<TrangThaiPhong> TrangThaiPhongs { get; set;}
        public DbSet<DatPhong> DatPhongs { get; set;}
        public DbSet<LoaiPhong> LoaiPhongs { get; set;}
        public DbSet<Phong> Phongs { get; set;}
        public DbSet<KhachHang> KhachHangs { get; set;}
        public DbSet<HoaDon> HoaDons { get; set;}
        public DbSet<KhachSan> KhachSans  { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<TrangThaiPhong>().HasKey(tKey => new {tKey.maPhong, tKey.ngay});
        }
    }
}
