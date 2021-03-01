using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer.Repositories
{
    public class AddressRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            //Act
            var result = addressRepository.Save(address);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void SaveInValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address() { City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            //Act
            var result = addressRepository.Save(address);

            //Assert            
            Assert.False(result);
        }

        [Fact]
        public void SaveNoChangesTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address();

            //Act
            var result = addressRepository.Save(address);

            //Assert            
            Assert.False(result);
        }


        [Fact]
        public void SaveLoadTwiceWithChangesTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };
            addressRepository.Save(address);
            var loadedAddress = addressRepository.Load(address.Guid);
            loadedAddress.City = "Unknown";

            //Act
            var saveResult = addressRepository.Save(loadedAddress);
            var result = addressRepository.Load(loadedAddress.Guid);

            //Assert            
            Assert.True(saveResult);
            Assert.NotEqual(address, loadedAddress);
            Assert.NotEqual(loadedAddress, result);
            Assert.NotEqual(address, result);
            Assert.Equal(address.Guid, loadedAddress.Guid);
            Assert.Equal(address.Guid, result.Guid);
            Assert.NotEqual(address.City, loadedAddress.City);
            Assert.Equal(loadedAddress.City, result.City);
        }

        [Fact]
        public void SaveLoadTwiceNoChangesTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };
            addressRepository.Save(address);
            var loadedAddress = addressRepository.Load(address.Guid);

            //Act
            var saveResult = addressRepository.Save(loadedAddress);
            var result = addressRepository.Load(loadedAddress.Guid);

            //Assert            
            Assert.False(saveResult);
            Assert.NotEqual(address, loadedAddress);
            Assert.NotEqual(loadedAddress, result);
            Assert.NotEqual(address, result);
            Assert.Equal(address.Guid, loadedAddress.Guid);
            Assert.Equal(address.Guid, result.Guid);
            Assert.Equal(address.City, loadedAddress.City);
            Assert.Equal(loadedAddress.City, result.City);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };
            var address2 = new Address() { StreetLine1 = "Perfect 6 street", City = "Perfect Town", StateOrRegion = "PS", Country = "Perfactionland", Code = "32592", Type = AddressType.Home };

            addressRepository.Save(address);
            addressRepository.Save(address2);

            //Act
            var result = addressRepository.Load(address.Guid);
            var result2 = addressRepository.Load(address2.Guid);

            //Assert            
            Assert.NotEqual(address, result);
            Assert.Equal(address.Guid, result.Guid);
            Assert.Equal(address.StreetLine1, result.StreetLine1);
            Assert.Equal(address.StreetLine2, result.StreetLine2);
            Assert.Equal(address.City, result.City);
            Assert.Equal(address.State, result.State);
            Assert.Equal(address.Country, result.Country);
            Assert.Equal(address.Code, result.Code);
            Assert.Equal(address.Type, result.Type);

            Assert.NotEqual(address2, result2);
            Assert.Equal(address2.Guid, result2.Guid);
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

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            addressRepository.Save(address);

            //Act
            var result = addressRepository.Load(Guid.NewGuid());

            //Assert            
            Assert.NotEqual(address, result);
            Assert.Null(result);
        }
    }
}
