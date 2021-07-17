using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrderFullfillment.Entity.Entities;
using OrderFullfillment.Entity.Entities.Basket;
using OrderFullfillment.Entity.Entities.Invoice;
using OrderFullfillment.Entity.Entities.Orders;
using OrderFullfillment.Entity.SeedWorks;

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
        
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((EntityBase)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
    
    // public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    // {
    //     public AppDbContext CreateDbContext(string[] args)
    //     {
    //         var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    //         optionsBuilder.UseSqlite("DataSource=order-fullfillment.db");
    //
    //         return new AppDbContext(optionsBuilder.Options);
    //     }
    // }
}