using E_CommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products").Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().HasMany(x => x.Categories).WithMany(x => x.Products).
                UsingEntity<ProductCategories>();
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<ProductCategories>().ToTable("ProductCategories").HasKey(x => x.Id);
            modelBuilder.Entity<ProductCategories>().HasIndex(x=> new { x.ProductId , x.CategoryId}).IsUnique();
            //modelBuilder.Entity<ProductCategories>().HasIndex(x => x.CategoryId).IsUnique(false);


            modelBuilder.Entity<Order>().ToTable("Orders").Property(o => o.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(x => x.Completion).HasDefaultValue("No");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems").Property(i => i.Price).HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>().Property(i => i.Quantity).HasDefaultValue(1);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);

        }
    }
}
