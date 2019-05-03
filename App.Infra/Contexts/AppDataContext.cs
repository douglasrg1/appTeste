using System.Data.Entity;
using App.Domain.Entities;
using App.Infra.Mappings;

namespace App.Infra.Context
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base(@"Server=.\sqlexpress;DataBase=appTeste;User ID=sa;Password=Drg4821;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new Usermap());
        }
    }
}