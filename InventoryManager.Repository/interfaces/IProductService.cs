using InventoryManager.Repository.Models;

public interface IProductService
{
    Product? Get(int id);
    IEnumerable<Product> Get();

    void Create(Product product);
    void Update(Product product);
    void Delete(int id);
}
