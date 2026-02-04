using InventoryManager.Repository.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InventoryManager.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public ProductRepository(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public void Create(Product product)
    {
        _context.Products.AddAsync(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Product product = new Product() { Id = id };
        _context.Products.Attach(product);
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public Product? Get(int id)
    {
        return _context.Products.Find(id);
    }

    public List<Product> Get()
    {
        return _context.Products.ToList();
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public int GetTotalProducts()
    {
        int total_products = 0;
        using (
            SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection")
            )
        )
        {
            SqlCommand cmd = new SqlCommand("SELECT count(id) from Products", conn);
            conn.Open();
            total_products = (int)cmd.ExecuteScalar();
            conn.Close();
        }
        return total_products;
    }
}
