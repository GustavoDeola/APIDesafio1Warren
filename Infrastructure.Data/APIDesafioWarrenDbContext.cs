using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class APIDesafioWarrenDbContext : DbContext
    {
        public APIDesafioWarrenDbContext(DbContextOptions<APIDesafioWarrenDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}