using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests.Repositories
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var customerRepository = new CustomerRepository();
            
            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            
            //Act
            var result = customerRepository.Save(customer);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void SaveWithAddressValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository(addressRepository);

            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };
            addressRepository.Save(address);

            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            customer.Addresses.Add(address);
            

            //Act
            var result = customerRepository.Save(customer);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var customerRepository = new CustomerRepository(addressRepository);

            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };
            var address2 = new Address(2) { StreetLine1 = "Perfect 6 street", City = "Perfect Town", State = "PS", Country = "Perfactionland", Code = "32592", Type = 1 };
            addressRepository.Save(address);
            addressRepository.Save(address2);

            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            customer.Addresses.Add(address);

            var customer2 = new Customer(2) { FirstName = "Mike", LastName = "Tay", Email = "mt@gmail.com" };
            customer2.Addresses.Add(address);
            customer2.Addresses.Add(address2);

            customerRepository.Save(customer);
            customerRepository.Save(customer2);

            //Act
            var result = customerRepository.Load(1);
            var result2 = customerRepository.Load(2);

            //Assert            
            Assert.NotEqual(customer, result);
            Assert.Equal(customer.Id, result.Id);
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
            Assert.Equal(customer2.Id, result2.Id);
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
            
            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            
            customerRepository.Save(customer);

            //Act
            var result = customerRepository.Load(2);

            //Assert            
            Assert.NotEqual(customer, result);
            Assert.Null(result);
        }
    }
}
