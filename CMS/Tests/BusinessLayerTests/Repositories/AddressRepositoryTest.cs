using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests.Repositories
{
    public class AddressRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            
            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };
            
            //Act
            var result = addressRepository.Save(address);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };
            var address2 = new Address(2) { StreetLine1 = "Perfect 6 street", City = "Perfect Town", State = "PS", Country = "Perfactionland", Code = "32592", Type = 1 };

            addressRepository.Save(address);
            addressRepository.Save(address2);

            //Act
            var result = addressRepository.Load(1);
            var result2 = addressRepository.Load(2);

            //Assert            
            Assert.NotEqual(address, result);
            Assert.Equal(address.Id, result.Id);
            Assert.Equal(address.StreetLine1, result.StreetLine1);
            Assert.Equal(address.StreetLine2, result.StreetLine2);
            Assert.Equal(address.City, result.City);
            Assert.Equal(address.State, result.State);
            Assert.Equal(address.Country, result.Country);
            Assert.Equal(address.Code, result.Code);
            Assert.Equal(address.Type, result.Type);

            Assert.NotEqual(address2, result2);
            Assert.Equal(address2.Id, result2.Id);
            Assert.Equal(address2.StreetLine1, result2.StreetLine1);
            Assert.Equal(address2.StreetLine2, result2.StreetLine2);
            Assert.Equal(address2.City, result2.City);
            Assert.Equal(address2.State, result2.State);
            Assert.Equal(address2.Country, result2.Country);
            Assert.Equal(address2.Code, result2.Code);
            Assert.Equal(address2.Type, result2.Type);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            addressRepository.Save(address);

            //Act
            var result = addressRepository.Load(2);

            //Assert            
            Assert.NotEqual(address, result);
            Assert.Null(result);
        }
    }
}
