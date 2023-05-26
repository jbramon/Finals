using Microsoft.EntityFrameworkCore;
using Customers.Models;
using Orders.Models;

namespace Customers.Contexts
{ 
    


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> items { get; set; }
    }
}
