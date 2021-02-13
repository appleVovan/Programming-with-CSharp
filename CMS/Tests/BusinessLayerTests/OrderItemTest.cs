using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests
{
    public class OrderItemTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var orderItem = new OrderItem(1, 1) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.True(actual);
        }
        
        [Fact]
        public void ValidateNoPrice()
        {
            //Arrange
            var orderItem = new OrderItem(1, 1) { ProductId = 1, Quantity = 1 };

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoQTY()
        {
            //Arrange
            var orderItem = new OrderItem(1, 1) { ProductId = 1, PurchasePrice = 10.00 };

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyOrder()
        {
            //Arrange
            var orderItem = new OrderItem(1, 1);

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.False(actual);
        }
    }
}
