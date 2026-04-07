using Elmex.InventoryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Elmex.InventoryApi.Data
{
    // Inheriting from DbContext gives this class all the magic SQL powers
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // A DbSet represents a Table in your SQL Database.
        // We are telling EF Core: "Create a table for Products and a table for Suppliers!"
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    }
}