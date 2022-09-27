using Microsoft.AspNetCore.Mvc;
using HonestProduct.Models;
using HonestProduct.Repositories;
using HonestProduct.Dtos;

namespace HonestProduct.Controllers;

[ApiController]
[Route("api/v1")]
public class ProductController : Controller
{
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _repository.GetAll();
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
        var product = _repository.GetProduct(id);
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
        _repository.CreateProduct(product);
        return Ok(new
        {
            message = "product inserted successfully",
            product = product
        });
    }
}