using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer
{
    public class AddressTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            //Act
            var actual = address.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoStreetLine1()
        {
            //Arrange
            var address = new Address() { City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            //Act
            var actual = address.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoCity()
        {
            //Arrange
            var address = new Address() { StreetLine1 = "Awesome 5 street", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            //Act
            var actual = address.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyAddress()
        {
            //Arrange
            var address = new Address();

            //Act
            var actual = address.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void AddressCounterTest()
        {
            //Arrange
            var address = new Address();
            var address1 = new Address();
            var address2 = new Address();

            //Act            

            //Assert
            Assert.NotEqual(address.Guid, address1.Guid);
            Assert.NotEqual(address.Guid, address2.Guid);
            Assert.NotEqual(address1.Guid, address2.Guid);
        }
    }
}
