using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer
{
    public class OrderItemTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var orderItem = new OrderItem(1) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ValidateNoPrice()
        {
            //Arrange
            var orderItem = new OrderItem(1) { ProductGuid = Guid.NewGuid(), Quantity = 1 };

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateNoQTY()
        {
            //Arrange
            var orderItem = new OrderItem(1) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00 };

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyOrder()
        {
            //Arrange
            var orderItem = new OrderItem(1);

            //Act
            var actual = orderItem.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void OrderItemCounterTest()
        {
            //Arrange
            var orderItem = new OrderItem(1);
            var orderItem1 = new OrderItem(1);
            var orderItem2 = new OrderItem(1);

            //Act            

            //Assert
            Assert.NotEqual(orderItem.Guid, orderItem1.Guid);
            Assert.NotEqual(orderItem.Guid, orderItem2.Guid);
            Assert.NotEqual(orderItem1.Guid, orderItem2.Guid);
        }
    }
}
