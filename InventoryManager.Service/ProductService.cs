using InventoryManager.Repository.Models;

namespace InventoryManager.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(Product product)
    {
        if (product.Price < 0)
            throw new Exception("Product price must not be less than 0");
        _productRepository.Create(product);
    }

    public void DeleteProductById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.Get();
    }

    public Product? GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
