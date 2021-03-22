using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLog>()
                .Property(e => e.userID)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.brandID)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.discountID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.userID)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.discountID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.imageLink)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.brandID)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleID)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.roleID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
