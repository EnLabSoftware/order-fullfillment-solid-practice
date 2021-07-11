using Microsoft.EntityFrameworkCore;
using OrderFullfillment.Entities;
using OrderFullfillment.Entities.Basket;
using OrderFullfillment.Entities.Invoice;
using OrderFullfillment.Entities.Order;

namespace OrderFullfillment.Repositories
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