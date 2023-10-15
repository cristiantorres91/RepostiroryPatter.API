using Microsoft.EntityFrameworkCore;
using RepostiroryPatter.API.Models;

namespace RepostiroryPatter.API.Infraestructure
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
    }
}
