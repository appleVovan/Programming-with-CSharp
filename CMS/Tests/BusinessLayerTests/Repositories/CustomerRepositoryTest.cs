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
            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            var customerRepository = new CustomerRepository();

            //Act
            var result = customerRepository.Save(customer);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            var customerRepository = new CustomerRepository();
            customerRepository.Save(customer);

            //Act
            var result = customerRepository.Load(1);

            //Assert            
            Assert.NotEqual(customer, result);
            Assert.Equal(customer.Id, result.Id);
            Assert.Equal(customer.FirstName, result.FirstName);
            Assert.Equal(customer.LastName, result.LastName);
            Assert.Equal(customer.Email, result.Email);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yvr@gmail.com" };
            var customerRepository = new CustomerRepository();
            customerRepository.Save(customer);

            //Act
            var result = customerRepository.Load(2);

            //Assert            
            Assert.NotEqual(customer, result);
            Assert.Null(result);
        }
    }
}
