using Ecommerece_DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerece_DAL.Context
{
    public class EccomereceDBContext :IdentityDbContext<ApplicationUser>
    {
        public EccomereceDBContext(DbContextOptions options) : base(options) { }
        public DbSet<ApplicationUser> Users {  get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryPhoto>CategoryPhoto { get; set; }
        public DbSet <Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_Product> Order_Product { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order_Product>().HasNoKey();
 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If DbContextOptions are not configured, configure using UseSqlServer
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionStrings",
                    x => x.MigrationsAssembly("Ecommerece_DAL"));
            }
        }

    }
}
