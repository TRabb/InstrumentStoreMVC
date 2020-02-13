using InstrumentStoreMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InstrumentStoreMVC.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<StoreDetail> StoreDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}