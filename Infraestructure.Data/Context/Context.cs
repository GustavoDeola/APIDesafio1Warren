using Domain.Models;
using Infraestructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}