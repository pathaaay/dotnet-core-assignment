using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Repository.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public int Price { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
}
