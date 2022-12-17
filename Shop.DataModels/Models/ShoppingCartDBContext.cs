using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Shop.DataModels.Models
{
    public partial class ShoppingCartDBContext : DbContext
    {
        public ShoppingCartDBContext()
        {
        }

        public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminInfo> AdminInfos { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=LAPTOP-G3SIT7T1\\SQLEXPRESS;Database=ShoppingCartDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AdminInfo");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastLogin).HasMaxLength(25);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(6);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.LastLogin).HasMaxLength(25);

                entity.Property(e => e.MobileNo).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(6);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CustomerOrder");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.OrderId).HasMaxLength(9);

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.ShippingAddress).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.CreatedOn).HasMaxLength(25);

                entity.Property(e => e.OrderId).HasMaxLength(9);

                entity.Property(e => e.UpdatedOn).HasMaxLength(25);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
