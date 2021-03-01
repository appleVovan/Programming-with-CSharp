using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer
{
    public class ProductTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };

            //Act
            var actual = product.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoName()
        {
            //Arrange
            var product = new Product() { Description = "Trench", Price = 50.0 };

            //Act
            var actual = product.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoPrice()
        {
            //Arrange
            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench" };

            //Act
            var actual = product.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyProduct()
        {
            //Arrange
            var product = new Product();

            //Act
            var actual = product.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ProductGuidTest()
        {
            //Arrange
            var product = new Product();
            var product1 = new Product();
            var product2 = new Product();

            //Act            

            //Assert
            Assert.NotEqual(product.Guid, product1.Guid);
            Assert.NotEqual(product.Guid, product2.Guid);
            Assert.NotEqual(product1.Guid, product2.Guid);
        }
    }
}
