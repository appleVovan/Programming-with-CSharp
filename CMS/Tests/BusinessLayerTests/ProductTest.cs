using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests
{
    public class ProductTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };

            //Act
            var actual = product.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoName()
        {
            //Arrange
            var product = new Product(1) { Description = "Trench", Price = 50.0 };

            //Act
            var actual = product.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoPrice()
        {
            //Arrange
            var product = new Product(1) { Name = "Twenty One Pilots Vinyl", Description = "Trench" };

            //Act
            var actual = product.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyProduct()
        {
            //Arrange
            var product = new Product(1);

            //Act
            var actual = product.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}
