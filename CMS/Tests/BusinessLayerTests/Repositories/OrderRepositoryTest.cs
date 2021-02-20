using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer.Repositories
{
    public class OrderRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var orderRepository = new OrderRepository();

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerId = 1, Address = address };
            var orderItem = new OrderItem(order.Id) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };

            order.Items.Add(orderItem);

            //Act
            var result = orderRepository.Save(order);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void SaveInValidTest()
        {
            //Arrange
            var orderRepository = new OrderRepository();

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), Address = address };
            var orderItem = new OrderItem(order.Id) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };

            order.Items.Add(orderItem);

            //Act
            var result = orderRepository.Save(order);

            //Assert            
            Assert.False(result);
        }

        [Fact]
        public void SaveNoChangesTest()
        {
            //Arrange
            var orderRepository = new OrderRepository();

            var order = new Order();
            var orderItem = new OrderItem(order.Id) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };

            order.Items.Add(orderItem);

            //Act
            var result = orderRepository.Save(order);

            //Assert            
            Assert.False(result);
        }

        [Fact]
        public void SaveLoadTwiceWithChangesTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var orderRepository = new OrderRepository(addressRepository);

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };
            addressRepository.Save(address);

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerId = 1, Address = address };
            var orderItem = new OrderItem(order.Id) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };
            order.Items.Add(orderItem);

            orderRepository.Save(order);
            var loadedOrder = orderRepository.Load(order.Id);
            loadedOrder.CustomerId = 2;
            loadedOrder.Items[0].Quantity = 2;

            //Act
            var saveResult = orderRepository.Save(loadedOrder);
            var result = orderRepository.Load(loadedOrder.Id);

            //Assert            
            Assert.True(saveResult);
            Assert.NotEqual(order, loadedOrder);
            Assert.NotEqual(loadedOrder, result);
            Assert.NotEqual(order, result);
            Assert.Equal(order.Id, loadedOrder.Id);
            Assert.Equal(order.Id, result.Id);
            Assert.NotEqual(order.CustomerId, loadedOrder.CustomerId);
            Assert.Equal(loadedOrder.CustomerId, result.CustomerId);
            Assert.NotEqual(order.Items[0].Quantity, loadedOrder.Items[0].Quantity);
            Assert.Equal(loadedOrder.Items[0].Quantity, result.Items[0].Quantity);
        }

        [Fact]
        public void SaveLoadTwiceNoChangesTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var orderRepository = new OrderRepository(addressRepository);

            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };
            addressRepository.Save(address);

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerId = 1, Address = address };
            var orderItem = new OrderItem(order.Id) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };
            order.Items.Add(orderItem);

            orderRepository.Save(order);
            var loadedOrder = orderRepository.Load(order.Id);

            //Act
            var saveResult = orderRepository.Save(loadedOrder);
            var result = orderRepository.Load(loadedOrder.Id);

            //Assert            
            Assert.False(saveResult);
            Assert.NotEqual(order, loadedOrder);
            Assert.NotEqual(loadedOrder, result);
            Assert.NotEqual(order, result);
            Assert.Equal(order.Id, loadedOrder.Id);
            Assert.Equal(order.Id, result.Id);
            Assert.Equal(order.CustomerId, loadedOrder.CustomerId);
            Assert.Equal(loadedOrder.CustomerId, result.CustomerId);
            Assert.Equal(order.Items[0].Quantity, loadedOrder.Items[0].Quantity);
            Assert.Equal(loadedOrder.Items[0].Quantity, result.Items[0].Quantity);
        }


        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var addressRepository = new AddressRepository();
            var address = new Address() { StreetLine1 = "Awesome 5 street", City = "Awesome Town", StateOrRegion = "AS", Country = "United Satetes of Awesomeness", Code = "12492", Type = 1 };
            var address2 = new Address() { StreetLine1 = "Perfect 6 street", City = "Perfect Town", StateOrRegion = "PS", Country = "Perfactionland", Code = "32592", Type = 1 };
            addressRepository.Save(address);
            addressRepository.Save(address2);

            var orderRepository = new OrderRepository(addressRepository);

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerId = 1, Address = address };
            var orderItem = new OrderItem(order.Id) { ProductId = 1, PurchasePrice = 10.00, Quantity = 1 };
            order.Items.Add(orderItem);

            var order2 = new Order() { Date = new DateTime(2021, 01, 14, 16, 0, 0), CustomerId = 2, Address = address2 };
            var orderItem2 = new OrderItem(order2.Id) { ProductId = 2, PurchasePrice = 20.00, Quantity = 1 };
            order2.Items.Add(orderItem2);

            orderRepository.Save(order);
            orderRepository.Save(order2);

            //Act
            var result = orderRepository.Load(order.Id);
            var result2 = orderRepository.Load(order2.Id);

            //Assert            
            Assert.NotEqual(order, result);
            Assert.Equal(order.Id, result.Id);
            Assert.Equal(order.Date, result.Date);
            Assert.Equal(order.CustomerId, result.CustomerId);
            Assert.Equal(order.Address.Id, result.Address.Id);
            Assert.Equal(order.Items.Count, result.Items.Count);
            Assert.NotEqual(orderItem, result.Items[0]);
            Assert.Equal(orderItem.Id, result.Items[0].Id);
            Assert.Equal(orderItem.OrderId, result.Items[0].OrderId);
            Assert.Equal(orderItem.ProductId, result.Items[0].ProductId);
            Assert.Equal(orderItem.PurchasePrice, result.Items[0].PurchasePrice);
            Assert.Equal(orderItem.Quantity, result.Items[0].Quantity);

            Assert.NotEqual(order2, result2);
            Assert.Equal(order2.Id, result2.Id);
            Assert.Equal(order2.Date, result2.Date);
            Assert.Equal(order2.CustomerId, result2.CustomerId);
            Assert.Equal(order2.Address.Id, result2.Address.Id);
            Assert.Equal(order2.Items.Count, result2.Items.Count);
            Assert.NotEqual(orderItem2, result2.Items[0]);
            Assert.Equal(orderItem2.Id, result2.Items[0].Id);
            Assert.Equal(orderItem2.OrderId, result2.Items[0].OrderId);
            Assert.Equal(orderItem2.ProductId, result2.Items[0].ProductId);
            Assert.Equal(orderItem2.PurchasePrice, result2.Items[0].PurchasePrice);
            Assert.Equal(orderItem2.Quantity, result2.Items[0].Quantity);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0) };
            var orderRepository = new OrderRepository();
            orderRepository.Save(order);

            //Act
            var result = orderRepository.Load(0);

            //Assert            
            Assert.NotEqual(order, result);
            Assert.Null(result);
        }
    }
}
