using InventoryManager.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Repository;

public class ApplicationDbContext : DbContext
{
    // Constructor helps pass configuration options (like connection string) to the base class
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // This property represents the "Interns" table in your database
    public DbSet<Product> Products { get; set; }
}
