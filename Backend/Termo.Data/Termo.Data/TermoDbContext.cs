using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Data.Models;

namespace Termo.Data
{
    public class TermoDbContext : DbContext
    {
        public TermoDbContext(DbContextOptions options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added
                || q.State == EntityState.Modified))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<ChairLampTest> ChairLampTests { get; set; }
        public DbSet<ChairLampTestItem> ChairLampTestItems { get; set; }
        public DbSet<ToulousePieronTest> ToulousePieronTests { get; set; }
        public DbSet<BourdonTest> BourdonTests { get; set; }
    }
}
