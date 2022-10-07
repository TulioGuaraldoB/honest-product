using System.Data;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using HonestProduct.Infrastructure.Helpers;
using HonestProduct.Web.Models;
using HonestProduct.Web.Repositories;

namespace HonestProduct.Web.Tests.Repositories;

[Collection("Testing ProductRepository")]
public class ProductRepositoryTest
{
    public ProductRepositoryTest() { }

    [Fact]
    public void Should_Return_Success_On_Get_All_Products()
    {
        // Arrange
        var data = new List<Product> {
            new Product { Id = 1, Name = "product_mock_1", Brand = "brand_mock_1", Price = 5 },
            new Product { Id = 2, Name = "product_mock_2", Brand = "brand_mock_2", Price = 7 },
            new Product { Id = 3, Name = "product_mock_3", Brand = "brand_mock_3", Price = 10 }
         }.AsQueryable();

        var mockDbContext = new Mock<DataBaseContext>();
        var mockSet = new Mock<DbSet<Product>>();

        mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        // Act
        var repository = new Mock<ProductRepository>(mockDbContext.Object);
        var products = repository.Object.GetAll();

        // Assert
        Assert.NotNull(products);
        Assert.IsType<Product>(products);
        Assert.NotEmpty(products);
    }

    [Theory]
    [InlineData(1)]
    public void Should_Return_Success_On_Get_Product_By_Id(int productId)
    {
        // Arrange
        var data = new List<Product> {
            new Product { Id = 1, Name = "product_mock_1", Brand = "brand_mock_1", Price = 5 },
            new Product { Id = 2, Name = "product_mock_2", Brand = "brand_mock_2", Price = 7 },
            new Product { Id = 3, Name = "product_mock_3", Brand = "brand_mock_3", Price = 10 }
         }.AsQueryable();

        var mockDbContext = new Mock<DataBaseContext>();
        var mockSet = new Mock<DbSet<Product>>();

        mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        // Act
        var repository = new Mock<IProductRepository>();
        var product = repository.Object.GetProduct(productId);

        // Assert
        Assert.NotNull(product);
    }
}