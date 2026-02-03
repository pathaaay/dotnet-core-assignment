using System.Diagnostics;
using InventoryManager.Repository.Models;
using InventoryManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(IProductService productService, ILogger<HomeController> logger)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> products = _productService.GetAllProducts();
        return View(products);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _productService.AddProduct(product);
        ViewBag.message = "The product " + product.Name + " is saved successfully";
        return View();
    }

    public IActionResult Edit(int id)
    {
        ViewData["productId"] = id;
        return RedirectToAction("Home");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
