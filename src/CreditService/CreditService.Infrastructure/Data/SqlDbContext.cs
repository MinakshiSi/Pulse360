using CreditService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CreditService.Infrastructure.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<CreditProfile> CreditProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Score).IsRequired();
                entity.Property(e => e.LastUpdated).HasDefaultValueSql("GETDATE()");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
