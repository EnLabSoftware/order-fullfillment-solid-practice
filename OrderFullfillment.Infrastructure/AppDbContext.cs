using Microsoft.EntityFrameworkCore;
using OrderFullfillment.Entity.Entities;
using OrderFullfillment.Entity.Entities.Basket;
using OrderFullfillment.Entity.Entities.Invoice;
using OrderFullfillment.Entity.Entities.Order;

namespace OrderFullfillment.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CompanyInvoice> CompanyInvoices { get; set; }
        public DbSet<PersonalInvoice> PersonalInvoices { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}