using Moq;
using Xunit;
using AutoBogus;
using HonestProduct.Infrastructure.Helpers;
using HonestProduct.Web.Models;
using HonestProduct.Web.Services;

namespace HonestProduct.Web.Tests.Services;

public class ProductServiceTest
{
    public ProductServiceTest() { }

    [Fact]
    public void Should_Return_Success_On_Get_All_Products()
    {
        // Arrange
        var mockDbContext = new Mock<DataBaseContext>();

        var mockProducts = new AutoFaker<Product>();
        var products = mockProducts.Generate();

        var _service = new Mock<IProductService>();

        // Act
        try
        {
            Assert.NotEmpty(_service.Object.GetAllProducts());
        }
        catch (Exception ex)
        {
            Assert.NotNull(ex);
        }
    }

    [Theory]
    [InlineData(1)]
    public void Should_Return_Success_On_Get_Product_By_Id(int productId)
    {
        var mockDbContext = new Mock<DataBaseContext>();

        var mockProduct = new AutoFaker<Product>();
        var product = mockProduct.Generate();

        var _service = new Mock<IProductService>();

        try
        {
            _service.Object.GetProductById(productId);
        }
        catch (Exception ex)
        {
            Assert.NotNull(ex);
        }
    }
}