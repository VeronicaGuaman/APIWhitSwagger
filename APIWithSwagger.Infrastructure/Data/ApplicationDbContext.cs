using APIWhitSwagger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIWithSwagger.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        #endregion

        #region Properties
        public virtual DbSet<Product> Products { get; set; }
        #endregion

        #region Method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Stock);
                entity.Property(e => e.Price);

            });
        }
        #endregion
    }
}
