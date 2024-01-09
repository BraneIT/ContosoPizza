using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public class ContosoPizzaContext : DbContext
    {
        public ContosoPizzaContext(DbContextOptions<ContosoPizzaContext> options) : base(options) { }
        public DbSet<ContosoPizza.Models.Product> Product { get; set; } = default!;
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryPerson> DeliveryPerson { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
