using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Models
{
    public class ProductsDbContext : DbContext
    {
        string connectionString;

        public ProductsDbContext()
        {
            connectionString = "server=.;database=FastShopping;integrated security=true; MultipleActiveResultSets=True;trustservercertificate=true";
        }

        public ProductsDbContext(string path) : base()
        {
            connectionString = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder
             optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

       
        public DbSet<ProductsAPI.Models.Products> Products { get; set; }

        public DbSet<ProductsAPI.Models.AddressDetails> AddressDetails { get; set; }

        public DbSet<ProductsAPI.Models.Cart> Cart { get; set; }

        public DbSet<ProductsAPI.Models.Orders> Orders { get; set; }

        public DbSet<ProductsAPI.Models.PaymentDetail> PaymentDetail { get; set; }
    }
}
