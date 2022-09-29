using Microsoft.AspNetCore.Mvc;
using HonestProduct.Models;
using HonestProduct.Services;
using HonestProduct.Dtos;

namespace HonestProduct.Controllers;

[ApiController]
[Route("api/v1/product")]
public class ProductController : Controller
{
    private IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _service.GetAllProducts();
        var productsRes = products.Select(product => new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            Price = product.Price,
        });

        return Ok(productsRes);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _service.GetProductById(id);
        var productRes = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            Price = product.Price,
        };

        return Ok(productRes);
    }

    [HttpPost]
    public IActionResult InsertProduct(Product product)
    {
        _service.CreateProduct(product);
        return Ok(new
        {
            message = "product inserted successfully",
            product = product
        });
    }
}