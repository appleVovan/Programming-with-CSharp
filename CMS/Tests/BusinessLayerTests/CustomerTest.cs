using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer
{
    public class CustomerTest
    {
        [Fact]
        public void FullNameTestValid()
        {
            //Arrange
            var customer = new Customer { FirstName = "Volodymyr", LastName = "Yablonskyi" };

            var expected = "Yablonskyi, Volodymyr";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameNoFirstNameTest()
        {
            //Arrange
            var customer = new Customer { LastName = "Yablonskyi" };

            var expected = "Yablonskyi";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FullNameNoLastNameTest()
        {
            //Arrange
            var customer = new Customer { FirstName = "Volodymyr" };

            var expected = "Volodymyr";

            //Act
            var actual = customer.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yablonskyi.v.reg@gmail.com" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoName()
        {
            //Arrange
            var customer = new Customer() { Email = "yablonskyi.v.reg@gmail.com" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoEmail()
        {
            //Arrange
            var customer = new Customer() { FirstName = "Volodymyr", LastName = "Yablonskyi" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyCustomer()
        {
            //Arrange
            var customer = new Customer();

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void CustomerGuidTest()
        {
            //Arrange
            var customer = new Customer();
            var customer1 = new Customer();
            var customer2 = new Customer();

            //Act            

            //Assert
            Assert.NotEqual(customer.Guid, customer1.Guid);
            Assert.NotEqual(customer.Guid, customer2.Guid);
            Assert.NotEqual(customer1.Guid, customer2.Guid);
        }
    }
}
