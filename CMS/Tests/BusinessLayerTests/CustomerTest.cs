using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests
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
        public void StaticTest()
        {
            //Arrange
            var customer = new Customer();
            customer.LastName = "Yablonskyi";
            Customer.InstanceCount += 1;

            var customer1 = new Customer();
            customer1.LastName = "Apple";
            Customer.InstanceCount += 1;

            var customer2 = new Customer();
            customer1.LastName = "Mohylnyi";
            Customer.InstanceCount += 1;

            var expected = 3;

            //Act
            var actual = Customer.InstanceCount;

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi", Email = "yablonskyi.v.reg@gmail.com"};

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.True(actual);
        }
        
        [Fact]
        public void ValidateNoName()
        {
            //Arrange
            var customer = new Customer(1) { Email = "yablonskyi.v.reg@gmail.com"};

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoEmail()
        {
            //Arrange
            var customer = new Customer(1) { FirstName = "Volodymyr", LastName = "Yablonskyi" };

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyCustomer()
        {
            //Arrange
            var customer = new Customer(1);

            //Act
            var actual = customer.Validate();

            //Assert
            Assert.False(actual);
        }


        [Fact]
        public void ObjectEqualityTest()
        {
            //Arrange
            var customer = new Customer { FirstName = "Volodymyr", LastName = "Yablonskyi" };
            var customer1 = customer;
            var customer2 = new Customer { FirstName = "Volodymyr", LastName = "Yablonskyi" };
            //Act

            //Assert
            Assert.Equal(customer, customer1);
            Assert.NotEqual(customer, customer2);
            Assert.Equal(customer.Id, customer2.Id);
            Assert.Equal(customer.FirstName, customer2.FirstName);
            Assert.Equal(customer.LastName, customer2.LastName);
            Assert.Equal(customer.Email, customer2.Email);
        }
    }
}
