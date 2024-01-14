using Microsoft.EntityFrameworkCore;

namespace WebApplicationDevelopment.Models.Entities
{
    public class MyContext : DbContext
    {        
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Storages { get; set; }
        public DbSet<Category> Categorys { get; set; }

        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=dbGB;Uid=gb;Pwd=123456;TrustServerCertificate=true")
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("ProductID");
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Price)
                .HasColumnName("Price")
                .IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.Count)
                .HasColumnName("ProductCount");

            });
        }
    }
}
