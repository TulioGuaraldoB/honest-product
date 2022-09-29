using HonestProduct.Models;
using HonestProduct.Repositories;

namespace HonestProduct.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    void CreateProduct(Product product);
}

public class ProductService : IProductService
{
    private IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        var products = _repository.GetAll();

        return products;
    }

    public Product GetProductById(int id)
    {
        var product = _repository.GetProduct(id);

        return product;
    }

    public void CreateProduct(Product product)
    {
        _repository.CreateProduct(product);
    }
}