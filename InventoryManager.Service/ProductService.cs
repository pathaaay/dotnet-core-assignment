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
        product.CreatedAt = DateTime.Now;

        if (product.Price < 0)
            throw new CustomException("Product price must not be less than 0");
        _productRepository.Create(product);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.Get();
    }

    public Product? GetProductById(int id)
    {
        return _productRepository.Get(id);
    }

    public void UpdateProduct(Product product)
    {
        if (product.Price < 0)
            throw new CustomException("Product price must not be less than 0");
        Console.WriteLine("productId", product.Id);
        _productRepository.Update(product);
    }

    public void DeleteProductById(int id)
    {
        _productRepository.Delete(id);
    }
}
