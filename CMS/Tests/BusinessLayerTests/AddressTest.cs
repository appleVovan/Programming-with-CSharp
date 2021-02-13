using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests
{
    public class AddressTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            //Act
            var actual = address.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoStreetLine1()
        {
            //Arrange
            var address = new Address(1) { City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            //Act
            var actual = address.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoCity()
        {
            //Arrange
            var address = new Address(1) { StreetLine1 = "Awesome 5 street", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            //Act
            var actual = address.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyAddress()
        {
            //Arrange
            var address = new Address(1);

            //Act
            var actual = address.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}
