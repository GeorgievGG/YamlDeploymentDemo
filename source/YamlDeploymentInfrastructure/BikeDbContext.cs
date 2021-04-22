using Microsoft.EntityFrameworkCore;
using YamlDeploymentDomain;

namespace YamlDeploymentInfrastructure
{
    public partial class BikeDbContext : DbContext
    {
        public BikeDbContext()
        {
        }

        public BikeDbContext(DbContextOptions<BikeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>(entity =>
            {
                entity.ToTable("Bike", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();


                entity.HasIndex(s => s.Name).IsUnique();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Price).IsRequired();

                entity.Property(e => e.Available).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}