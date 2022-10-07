using Xunit;
using Moq;
using HonestProduct.Infrastructure.Helpers;
using HonestProduct.Web.Models;
using HonestProduct.Web.Repositories;

namespace HonestProduct.Web.Tests.Repositories;

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
         }.AsEnumerable();

        var mockDbContext = new Mock<DataBaseContext>();

        // Act
        var repository = new Mock<ProductRepository>(mockDbContext.Object);
        var products = repository.Object.GetAll();

        // Assert
        Assert.NotNull(products);
        Assert.IsType<Product>(products);
    }
}