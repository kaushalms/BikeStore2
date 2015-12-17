using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BikeStore.Models
{
    public class BikeStoreEntities:DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Store> Stores { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        public DbSet<PayMode> PayModes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuss { get; set; }
        public DbSet<ProdStatus> ProdStatuss { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderStage> OrderStages { get; set; }
    }
}