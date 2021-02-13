using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests
{
    public class OrderTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            var order = new Order(1) { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerId = 1, Address = address };
            var orderItem = new OrderItem(1, 1) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };
            
            order.Items.Add(orderItem);

            //Act
            var actual = order.Validate();

            //Assert
            Assert.True(actual);
        }
        
        [Fact]
        public void ValidateNoDate()
        {
            //Arrange
            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            var order = new Order(1) { CustomerId = 1, Address = address };
            var orderItem = new OrderItem(1, 1) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };
            
            order.Items.Add(orderItem);

            //Act
            var actual = order.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoItems()
        {
            //Arrange
            var address = new Address(1) { StreetLine1 = "Awesome 5 street", City = "Awesome Town", State = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            var order = new Order(1) { CustomerId = 1, Address = address };

            //Act
            var actual = order.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyOrder()
        {
            //Arrange
            var order = new Order(1);

            //Act
            var actual = order.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}
