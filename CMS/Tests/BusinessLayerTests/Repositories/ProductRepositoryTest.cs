using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests.Repositories
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            var productRepository = new ProductRepository();

            //Act
            var result = productRepository.Save(product);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            var productRepository = new ProductRepository();
            productRepository.Save(product);

            //Act
            var result = productRepository.Load(1);

            //Assert            
            Assert.NotEqual(product, result);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            var productRepository = new ProductRepository();
            productRepository.Save(product);

            //Act
            var result = productRepository.Load(2);

            //Assert            
            Assert.NotEqual(product, result);
            Assert.Null(result);
        }
    }
}
