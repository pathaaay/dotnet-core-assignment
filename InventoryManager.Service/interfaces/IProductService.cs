using InventoryManager.Repository.Models;

public interface IProductService
{
    Product? GetProductById(int id);
    IEnumerable<Product> GetAllProducts();

    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProductById(int id);
}
