using BlazorProduct.Api.Models.Configuaration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProduct.Api.Models
{
    public class DBProducts : DbContext
    {
        public DBProducts(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
    }
}
