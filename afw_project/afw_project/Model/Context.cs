using Microsoft.EntityFrameworkCore;

namespace afw_project.Model
{
    class Context : DbContext
    {
        #region Database tables
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }
        #endregion


        #region Creating context methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ContextCredentials.Connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(k => k.CategoryID);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne(c => c.Customer).WithMany(o => o.Orders);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(c => new { c.OrderID, c.ProductID });
                entity.HasOne(p => p.Product).WithMany(o => o.ProductOrders).HasForeignKey(k => k.ProductID);
                entity.HasOne(o => o.Order).WithMany(p => p.ProductOrders).HasForeignKey(k => k.OrderID);
            });
        }
        #endregion
    }
}
