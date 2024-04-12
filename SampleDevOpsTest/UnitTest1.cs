using Moq;
using SampleDevops.Interfaces;
using SampleDevops.Models;
using SampleDevops.Repositories;

namespace SampleDevOpsTest
{
    public class UnitTest1
    {
        public Mock<IProductRepository> mock = new Mock<IProductRepository>();
        [Fact]
        public void GetProductByIdTester()
        {
            ProductEntity evt = new ProductEntity { ProductId = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Product1", Description = "Product Description", Design = "Modern", Size = 20, Price = 3000 };
            Guid id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            mock.Setup(p => p.GetProductById(id)).Returns(evt);
            ProductRepositoryBL productRepositoryBL = new ProductRepositoryBL(mock.Object);
            var result = productRepositoryBL.GetProductById(Guid.Parse("11111111-1111-1111-1111-111111111111"));
            Assert.NotNull(result);
            Assert.Equal(evt, result);
        }
        [Fact]
        public void GetAllProductsTester()
        {
            List<ProductEntity> evt = new List<ProductEntity>() { new ProductEntity { ProductId = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Product1", Description = "Product Description", Design = "Modern", Size = 20, Price = 3000 }, new ProductEntity { ProductId = Guid.Parse("11111111-1111-1111-1111-111111111122"), Name = "Product2", Description = "Product Description", Design = "Modern", Size = 20, Price = 3000 } };
            mock.Setup(p => p.GetAllProducts()).Returns(evt);
            ProductRepositoryBL productRepositoryBL = new ProductRepositoryBL(mock.Object);
            var result = productRepositoryBL.GetAllProducts();
            Assert.NotNull(result);
            Assert.Equal(evt, result);
        }
    }
}
