using Insurance.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infra.Context
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        public DbSet<InsuranceRequest> InsuranceRequests { get; set; }
        public DbSet<InsuranceCoverage> InsuranceCoverages { get; set; }
        public DbSet<RequestCoverage> RequestCoverages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceCoverage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.MinCapital).HasColumnType("decimal(18,2)");
                entity.Property(e => e.MaxCapital).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Rate).HasColumnType("decimal(18,6)");
            });

            modelBuilder.Entity<InsuranceRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.TotalPremium).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<RequestCoverage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Capital).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CalculatedPremium).HasColumnType("decimal(18,2)");

                entity.HasOne(rc => rc.InsuranceRequest)
                    .WithMany(r => r.Coverages)
                    .HasForeignKey(rc => rc.InsuranceRequestId);

                entity.HasOne(rc => rc.Coverage)
                    .WithMany(c => c.RequestCoverages)
                    .HasForeignKey(rc => rc.CoverageId);
            });


            // Seed data
            modelBuilder.Entity<InsuranceCoverage>().HasData(
                new InsuranceCoverage
                {
                    Id = 1,
                    Title = "پوشش جراحی",
                    MinCapital = 5000,
                    MaxCapital = 500000000,
                    Rate = 0.00520m
                },
                new InsuranceCoverage
                {
                    Id = 2,
                    Title = "پوشش دندانپزشکی",
                    MinCapital = 4000,
                    MaxCapital = 400000000,
                    Rate = 0.00420m
                },
                new InsuranceCoverage
                {
                    Id = 3,
                    Title = "پوشش بستری",
                    MinCapital = 2000,
                    MaxCapital = 200000000,
                    Rate = 0.00400m
                }
            );
        }
    }
}
