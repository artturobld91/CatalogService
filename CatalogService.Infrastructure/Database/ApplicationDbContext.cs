using CatalogService.Domain.Models;
using CatalogService.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        public string ConnectionString = string.Empty;

        public ApplicationDbContext()
        {
            // Getting user secrets
            var builder = new ConfigurationBuilder().AddUserSecrets<ConnectionStrings>().Build();
            ConnectionString = builder.GetSection("ConnectionStrings:SQLServer").Value;
            Console.WriteLine($"Connection String: {ConnectionString}");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
    }
}
