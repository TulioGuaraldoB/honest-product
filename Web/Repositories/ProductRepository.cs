using AutoMapper;
using HonestProduct.Infrastructure.Helpers;
using HonestProduct.Web.Models;

namespace HonestProduct.Web.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetAll();
    Product GetProduct(int id);
    void CreateProduct(Product product);
}

public class ProductRepository : IProductRepository
{
    private DataBaseContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(DataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<Product> GetAll()
    {
        return _context.Products.AsQueryable();
    }

    public Product GetProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            throw new KeyNotFoundException("Product not found!");

        return product;
    }

    public void CreateProduct(Product product)
    {
        if (_context.Products.Any(p => p.Name == product.Name))
            throw new AppException("Product:  '" + product.Name + "' already exists");

        var productReq = _mapper.Map<Product>(product);

        _context.Products.Add(productReq);
        _context.SaveChanges();
    }
}