using AspNetCoreIntroHw.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIntroHw.Context
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; init; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) 
        {
        }
    }
}
