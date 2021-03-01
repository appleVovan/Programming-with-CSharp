using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer.Repositories
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var customerRepository = new CustomerRepository();

            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };

            //Act
            var result = customerRepository.Save(customer);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void SaveInValidTest()
        {
            //Arrange
            var customerRepository = new CustomerRepository();

            var customer = new Customer() { FirstName = "Volodymyr", Email = "yvr@gmail.com" };

            //Act
            var result = customerRepository.Save(customer);

            //Assert            
            Assert.False(result);
        }

        [Fact]
        public void SaveNoChangesTest()
        {
            //Arrange
            var customerRepository = new CustomerRepository();

            var customer = new Customer();

            //Act
            var result = customerRepository.Save(customer);

            //Assert            
            Assert.False(result);
        }

        [Fact]
        public void SaveWithAddressValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository(addressRepository);

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };
            addressRepository.Save(address);

            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            customer.Addresses.Add(address);


            //Act
            var result = customerRepository.Save(customer);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void SaveLoadTwiceWithChangesTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository(addressRepository);

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };
            addressRepository.Save(address);

            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            customer.Addresses.Add(address);
            customerRepository.Save(customer);
            var loadedCustomer = customerRepository.Load(customer.Guid);
            loadedCustomer.LastName = "Apple";

            //Act
            var saveResult = customerRepository.Save(loadedCustomer);
            var result = customerRepository.Load(loadedCustomer.Guid);

            //Assert            
            Assert.True(saveResult);
            Assert.NotEqual(customer, loadedCustomer);
            Assert.NotEqual(loadedCustomer, result);
            Assert.NotEqual(customer, result);
            Assert.Equal(customer.Guid, loadedCustomer.Guid);
            Assert.Equal(customer.Guid, result.Guid);
            Assert.NotEqual(customer.LastName, loadedCustomer.LastName);
            Assert.Equal(loadedCustomer.LastName, result.LastName);
            Assert.Equal(loadedCustomer.Addresses[0].Guid, result.Addresses[0].Guid);
        }

        [Fact]
        public void SaveLoadTwiceNoChangesTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository(addressRepository);

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };
            addressRepository.Save(address);

            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            customer.Addresses.Add(address);
            customerRepository.Save(customer);
            var loadedCustomer = customerRepository.Load(customer.Guid);

            //Act
            var saveResult = customerRepository.Save(loadedCustomer);
            var result = customerRepository.Load(loadedCustomer.Guid);

            //Assert            
            Assert.False(saveResult);
            Assert.NotEqual(customer, loadedCustomer);
            Assert.NotEqual(loadedCustomer, result);
            Assert.NotEqual(customer, result);
            Assert.Equal(customer.Guid, loadedCustomer.Guid);
            Assert.Equal(customer.Guid, result.Guid);
            Assert.Equal(customer.LastName, loadedCustomer.LastName);
            Assert.Equal(loadedCustomer.LastName, result.LastName);
            Assert.Equal(loadedCustomer.Addresses[0].Guid, result.Addresses[0].Guid);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository(addressRepository);

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };
            var address2 = new Address() { StreetLine1 = "Perfect 6 street", City = "Perfect Town", StateOrRegion = "PS", Country = "Perfactionland", Code = "32592", Type = AddressType.Home };
            addressRepository.Save(address);
            addressRepository.Save(address2);

            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            customer.Addresses.Add(address);

            var customer2 = new Customer() { FirstName = "Mike", LastName = "Tay", Email = "mt@gmail.com" };
            customer2.Addresses.Add(address);
            customer2.Addresses.Add(address2);

            customerRepository.Save(customer);
            customerRepository.Save(customer2);

            //Act
            var result = customerRepository.Load(customer.Guid);
            var result2 = customerRepository.Load(customer2.Guid);

            //Assert            
            Assert.NotEqual(customer, result);
            Assert.Equal(customer.Guid, result.Guid);
            Assert.Equal(customer.FirstName, result.FirstName);
            Assert.Equal(customer.LastName, result.LastName);
            Assert.Equal(customer.Email, result.Email);
            Assert.Equal(customer.Addresses.Count, result.Addresses.Count);
            Assert.Equal(customer.Addresses[0].StreetLine1, result.Addresses[0].StreetLine1);
            Assert.Equal(customer.Addresses[0].City, result.Addresses[0].City);
            Assert.Equal(customer.Addresses[0].State, result.Addresses[0].State);
            Assert.Equal(customer.Addresses[0].Country, result.Addresses[0].Country);
            Assert.Equal(customer.Addresses[0].Code, result.Addresses[0].Code);
            Assert.Equal(customer.Addresses[0].Type, result.Addresses[0].Type);

            Assert.NotEqual(customer2, result2);
            Assert.Equal(customer2.Guid, result2.Guid);
            Assert.Equal(customer2.FirstName, result2.FirstName);
            Assert.Equal(customer2.LastName, result2.LastName);
            Assert.Equal(customer2.Email, result2.Email);
            Assert.Equal(customer2.Addresses.Count, result2.Addresses.Count);
            Assert.Equal(customer2.Addresses[0].StreetLine1, result2.Addresses[0].StreetLine1);
            Assert.Equal(customer2.Addresses[0].City, result2.Addresses[0].City);
            Assert.Equal(customer2.Addresses[0].State, result2.Addresses[0].State);
            Assert.Equal(customer2.Addresses[0].Country, result2.Addresses[0].Country);
            Assert.Equal(customer2.Addresses[0].Code, result2.Addresses[0].Code);
            Assert.Equal(customer2.Addresses[0].Type, result2.Addresses[0].Type);
            Assert.Equal(customer2.Addresses[1].StreetLine1, result2.Addresses[1].StreetLine1);
            Assert.Equal(customer2.Addresses[1].City, result2.Addresses[1].City);
            Assert.Equal(customer2.Addresses[1].State, result2.Addresses[1].State);
            Assert.Equal(customer2.Addresses[1].Country, result2.Addresses[1].Country);
            Assert.Equal(customer2.Addresses[1].Code, result2.Addresses[1].Code);
            Assert.Equal(customer2.Addresses[1].Type, result2.Addresses[1].Type);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var customerRepository = new CustomerRepository();

            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };

            customerRepository.Save(customer);

            //Act
            var result = customerRepository.Load(Guid.NewGuid());

            //Assert            
            Assert.NotEqual(customer, result);
            Assert.Null(result);
        }
    }
}
