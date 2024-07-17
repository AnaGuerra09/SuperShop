using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using System.Security.Cryptography.X509Certificates;

namespace SuperShop.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }
    }
}
