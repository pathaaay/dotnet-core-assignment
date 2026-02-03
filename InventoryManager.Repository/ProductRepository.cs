using InventoryManager.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
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

    public Product? Update(Product product)
    {
        var productToUpdate = _context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (productToUpdate != null)
        {
            productToUpdate = product;
            _context.SaveChanges();
        }

        return productToUpdate;
    }
}
