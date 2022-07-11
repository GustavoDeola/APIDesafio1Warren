using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}