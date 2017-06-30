using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAPI.Models
{
    public partial class ShopDBContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderdetail> Orderdetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Shopcart> Shopcart { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=shopdatabase.database.windows.net;Initial Catalog=ShopDB;Persist Security Info=True;User ID=uchihapeng;Password=.a201314");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ShoppingAddress).HasMaxLength(255);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName).HasMaxLength(255);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ShoppingAddress).HasMaxLength(500);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.ToTable("orderdetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProId).HasColumnName("ProID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__product__620295F05CF84D0C");

                entity.ToTable("product");

                entity.Property(e => e.ProId).HasColumnName("ProID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.PhotoSrc).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.Property(e => e.ProDescribe).HasMaxLength(255);

                entity.Property(e => e.ProName).HasMaxLength(255);
            });

            modelBuilder.Entity<Shopcart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__shopcart__51BCD7972E43EF51");

                entity.ToTable("shopcart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.ProId).HasColumnName("ProID");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_user");

                entity.ToTable("user");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.LoginName).HasMaxLength(255);

                entity.Property(e => e.NickName).HasMaxLength(255);

                entity.Property(e => e.PassWord).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.RealName).HasMaxLength(255);

                entity.Property(e => e.RegisterTime).HasColumnType("datetime");
            });
        }
    }
}