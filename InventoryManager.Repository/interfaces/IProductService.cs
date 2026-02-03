using InventoryManager.Repository.Models;

public interface IProductRepository
{
    Product? Get(int id);
    List<Product> Get();

    void Create(Product product);

    void Update(Product product);

    void Delete(int id);
}
