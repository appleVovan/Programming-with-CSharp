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
            var productRepository = new ProductRepository();
            
            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            
            //Act
            var result = productRepository.Save(product);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            var product2 = new Product(2) { Name = "Balthazar Vinyl", Description = "Thin Walls", Price = 60.0 };
            
            productRepository.Save(product);
            productRepository.Save(product2);

            //Act
            var result = productRepository.Load(1);
            var result2 = productRepository.Load(2);

            //Assert            
            Assert.NotEqual(product, result);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);

            Assert.NotEqual(product2, result2);
            Assert.Equal(product2.Id, result2.Id);
            Assert.Equal(product2.Name, result2.Name);
            Assert.Equal(product2.Description, result2.Description);
            Assert.Equal(product2.Price, result2.Price);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            
            productRepository.Save(product);

            //Act
            var result = productRepository.Load(2);

            //Assert            
            Assert.NotEqual(product, result);
            Assert.Null(result);
        }
    }
}
