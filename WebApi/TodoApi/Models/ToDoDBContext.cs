using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TodoApi.Models
{
    public partial class ToDoDBContext : DbContext
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=40.71.87.251;Initial Catalog=ToDoDB;Persist Security Info=True;User ID=sa;Password=.uchihapeng00");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ShoppingAddress).HasMaxLength(255);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.BrandId)
                    .HasColumnName("BrandID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandName).HasMaxLength(255);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ShoppingAddress).HasMaxLength(500);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.ToTable("orderdetail");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProId).HasColumnName("ProID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("product");

                entity.Property(e => e.ProId)
                    .HasColumnName("ProID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.PhotoSrc).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProDescribe).HasMaxLength(255);

                entity.Property(e => e.ProName).HasMaxLength(255);
            });

            modelBuilder.Entity<Shopcart>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("shopcart");

                entity.Property(e => e.CartId)
                    .HasColumnName("CartID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProId).HasColumnName("ProID");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("user");

                entity.Property(e => e.Uid).ValueGeneratedNever();

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
