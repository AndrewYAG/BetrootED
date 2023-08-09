using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHW.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFrameworkHW
{
    internal class ShopDbContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<Product> Products { get; set; }

        public ShopDbContext() : base("Server=DESKTOP-T5EIHIV\\TEST1;Database=OrdersDB;Trusted_Connection=True")
        {
        }

/*        protected override void OnCunfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-T5EIHIV\\TEST1;Database=ordersDB;Trusted_Connetction=True");
            optionsBuilder.LogTo(Console.WriteLine);
        }*/
    }
}
