using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer
{
    public class OrderTest
    {
        [Fact]
        public void ValidateValid()
        {
            //Arrange
            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            var order = new Order() { Date = new DateTimeOffset(2021, 01, 14, 15, 0, 0, new TimeSpan(2, 0, 0)), CustomerGuid = Guid.NewGuid(), Address = address };
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };

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
            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            var order = new Order() { CustomerGuid = Guid.NewGuid(), Address = address };
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };

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
            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = AddressType.Home };

            var order = new Order() { CustomerGuid = Guid.NewGuid(), Address = address };

            //Act
            var actual = order.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateEmptyOrder()
        {
            //Arrange
            var order = new Order();

            //Act
            var actual = order.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void OrderCounterTest()
        {
            //Arrange
            var order = new Order();
            var order1 = new Order();
            var order2 = new Order();

            //Act            

            //Assert
            Assert.Equal(order1.Id, order.Id + 1);
            Assert.Equal(order2.Id, order1.Id + 1);
        }

        [Fact]
        public void OrderGuidTest()
        {
            //Arrange
            var order = new Order();
            var order1 = new Order();
            var order2 = new Order();

            //Act            

            //Assert
            Assert.NotEqual(order.Guid, order1.Guid);
            Assert.NotEqual(order.Guid, order2.Guid);
            Assert.NotEqual(order1.Guid, order2.Guid);
        }
    }
}
