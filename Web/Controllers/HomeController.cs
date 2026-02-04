using System.Diagnostics;
using InventoryManager.Repository.Models;
using InventoryManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService, ILogger<HomeController> logger)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        ViewData["total_products"] = _productService.GetTotalProductCount();

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
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        try
        {
            _productService.AddProduct(product);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError("Price", ex.Message);
            return View(product);
        }
    }

    public IActionResult Edit(int id)
    {
        Product? product = _productService.GetProductById(id);
        if (product == null)
            return RedirectToAction("index");
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        try
        {
            _productService.UpdateProduct(product);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(ex.Message.Split("|")[0], ex.Message.Split("|")[1]);
            return View(product);
        }
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _productService.DeleteProductById(id);
        return RedirectToAction("index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
