using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using System;
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
        
    }
}
