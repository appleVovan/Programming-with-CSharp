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

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerGuid = Guid.NewGuid(), Address = address };
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };

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
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };

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
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };

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

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerGuid = Guid.NewGuid(), Address = address };
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };
            order.Items.Add(orderItem);

            orderRepository.Save(order);
            var loadedOrder = orderRepository.Load(order.Guid);
            loadedOrder.CustomerGuid = Guid.NewGuid();
            loadedOrder.Items[0].Quantity = 2;

            //Act
            var saveResult = orderRepository.Save(loadedOrder);
            var result = orderRepository.Load(loadedOrder.Guid);

            //Assert            
            Assert.True(saveResult);
            Assert.NotEqual(order, loadedOrder);
            Assert.NotEqual(loadedOrder, result);
            Assert.NotEqual(order, result);
            Assert.Equal(order.Guid, loadedOrder.Guid);
            Assert.Equal(order.Guid, result.Guid);
            Assert.NotEqual(order.CustomerGuid, loadedOrder.CustomerGuid);
            Assert.Equal(loadedOrder.CustomerGuid, result.CustomerGuid);
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

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerGuid = Guid.NewGuid(), Address = address };
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };
            order.Items.Add(orderItem);

            orderRepository.Save(order);
            var loadedOrder = orderRepository.Load(order.Guid);

            //Act
            var saveResult = orderRepository.Save(loadedOrder);
            var result = orderRepository.Load(loadedOrder.Guid);

            //Assert            
            Assert.False(saveResult);
            Assert.NotEqual(order, loadedOrder);
            Assert.NotEqual(loadedOrder, result);
            Assert.NotEqual(order, result);
            Assert.Equal(order.Guid, loadedOrder.Guid);
            Assert.Equal(order.Guid, result.Guid);
            Assert.Equal(order.CustomerGuid, loadedOrder.CustomerGuid);
            Assert.Equal(loadedOrder.CustomerGuid, result.CustomerGuid);
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

            var order = new Order() { Date = new DateTime(2021, 01, 14, 15, 0, 0), CustomerGuid = Guid.NewGuid(), Address = address };
            var orderItem = new OrderItem(order.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 10.00, Quantity = 1 };
            order.Items.Add(orderItem);

            var order2 = new Order() { Date = new DateTime(2021, 01, 14, 16, 0, 0), CustomerGuid = Guid.NewGuid(), Address = address2 };
            var orderItem2 = new OrderItem(order2.Guid) { ProductGuid = Guid.NewGuid(), PurchasePrice = 20.00, Quantity = 1 };
            order2.Items.Add(orderItem2);

            orderRepository.Save(order);
            orderRepository.Save(order2);

            //Act
            var result = orderRepository.Load(order.Guid);
            var result2 = orderRepository.Load(order2.Guid);

            //Assert            
            Assert.NotEqual(order, result);
            Assert.Equal(order.Guid, result.Guid);
            Assert.Equal(order.Date, result.Date);
            Assert.Equal(order.CustomerGuid, result.CustomerGuid);
            Assert.Equal(order.Address.Guid, result.Address.Guid);
            Assert.Equal(order.Items.Count, result.Items.Count);
            Assert.NotEqual(orderItem, result.Items[0]);
            Assert.Equal(orderItem.Guid, result.Items[0].Guid);
            Assert.Equal(orderItem.OrderGuid, result.Items[0].OrderGuid);
            Assert.Equal(orderItem.ProductGuid, result.Items[0].ProductGuid);
            Assert.Equal(orderItem.PurchasePrice, result.Items[0].PurchasePrice);
            Assert.Equal(orderItem.Quantity, result.Items[0].Quantity);

            Assert.NotEqual(order2, result2);
            Assert.Equal(order2.Guid, result2.Guid);
            Assert.Equal(order2.Date, result2.Date);
            Assert.Equal(order2.CustomerGuid, result2.CustomerGuid);
            Assert.Equal(order2.Address.Guid, result2.Address.Guid);
            Assert.Equal(order2.Items.Count, result2.Items.Count);
            Assert.NotEqual(orderItem2, result2.Items[0]);
            Assert.Equal(orderItem2.Guid, result2.Items[0].Guid);
            Assert.Equal(orderItem2.OrderGuid, result2.Items[0].OrderGuid);
            Assert.Equal(orderItem2.ProductGuid, result2.Items[0].ProductGuid);
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
            var result = orderRepository.Load(Guid.NewGuid());

            //Assert            
            Assert.NotEqual(order, result);
            Assert.Null(result);
        }
    }
}
