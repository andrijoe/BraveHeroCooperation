using BraveHeroCooperation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BraveHeroCooperation.Data
{ 
    public class AppDbContext : DbContext
    {
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Access> Accesses => Set<Access>();
        public DbSet<Configuration> Configurations => Set<Configuration>();
        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<Installment> Installments => Set<Installment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(config.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Member)
                .WithMany(m => m.Loans)
                .HasForeignKey(l => l.MemberId);

            modelBuilder.Entity<Installment>()
                .HasOne(i => i.Loan)
                .WithMany(l => l.Installments)
                .HasForeignKey(i => i.LoanId);

            modelBuilder.Entity<Access>()
                .HasOne(a => a.Member)
                .WithMany(m => m.Accesses)
                .HasForeignKey(a => a.MemberId);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var idProp = entity.FindProperty("Id");
                if (idProp != null)
                {
                    idProp.SetValueGenerationStrategy(
                        NpgsqlValueGenerationStrategy.SerialColumn
                    );
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
