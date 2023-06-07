using ApiPizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace ApiPizza.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Tablas candidatas a tablas
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("DbProduct");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
