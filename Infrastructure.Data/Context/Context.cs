using Domain.Models;
using EntityFrameworkCore.AutoHistory.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Infrastructure.Data"));
        }

        public override int SaveChanges()
        {
            var addedEntities = this.DetectChanges(EntityState.Added);

            this.EnsureAutoHistory();
            var affectedRows = base.SaveChanges();

            this.EnsureAutoHistory(addedEntities);
            affectedRows += base.SaveChanges();

            return affectedRows;
        }
        public DbSet<Customer> Customers { get; set; }
    }
}