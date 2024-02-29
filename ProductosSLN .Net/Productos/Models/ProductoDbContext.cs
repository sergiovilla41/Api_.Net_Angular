using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Productos.Models
{
    public class ProductoDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Productos> Productos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Categoria> Categoria { get; set; }

    }
}
