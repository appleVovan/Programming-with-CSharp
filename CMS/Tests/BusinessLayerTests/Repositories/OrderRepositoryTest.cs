using AR.ProgrammingWithCSharp.CMS.BusinessLayer;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayerTests.Repositories
{
    public class OrderRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var order = new Order(1) { Date = new System.DateTime(2021, 01, 14, 15, 0, 0) };
            var item = new OrderItem(1, order.Id);
            item.ProductId = 1;
            item.PurchasePrice = 10.00;
            item.Quantity = 1;
            order.Items.Add(item);
            var orderRepository = new OrderRepository();

            //Act
            var result = orderRepository.Save(order);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var order = new Order(1) { Date = new System.DateTime(2021, 01, 14, 15, 0, 0) };
            var item = new OrderItem(1, order.Id);
            item.ProductId = 1;
            item.PurchasePrice = 10.00;
            item.Quantity = 1;
            order.Items.Add(item);

            var order2 = new Order(2) { Date = new System.DateTime(2021, 01, 15, 15, 0, 0) };
            var item2 = new OrderItem(2, order2.Id);
            item2.ProductId = 2;
            item2.PurchasePrice = 20.00;
            item2.Quantity = 1;
            order2.Items.Add(item2);

            var orderRepository = new OrderRepository();
            orderRepository.Save(order);
            orderRepository.Save(order2);

            //Act
            var result = orderRepository.Load(1);
            var result2 = orderRepository.Load(2);

            //Assert            
            Assert.NotEqual(order, result);
            Assert.Equal(order.Id, result.Id);
            Assert.Equal(order.Date, result.Date);
            Assert.Equal(order.Items.Count, result.Items.Count);
            Assert.NotEqual(item, result.Items[0]);
            Assert.Equal(item.Id, result.Items[0].Id);
            Assert.Equal(item.OrderId, result.Items[0].OrderId);
            Assert.Equal(item.ProductId, result.Items[0].ProductId);
            Assert.Equal(item.PurchasePrice, result.Items[0].PurchasePrice);
            Assert.Equal(item.Quantity, result.Items[0].Quantity);

            Assert.NotEqual(order2, result2);
            Assert.Equal(order2.Id, result2.Id);
            Assert.Equal(order2.Date, result2.Date);
            Assert.Equal(order2.Items.Count, result2.Items.Count);
            Assert.NotEqual(item2, result2.Items[0]);
            Assert.Equal(item2.Id, result2.Items[0].Id);
            Assert.Equal(item2.OrderId, result2.Items[0].OrderId);
            Assert.Equal(item2.ProductId, result2.Items[0].ProductId);
            Assert.Equal(item2.PurchasePrice, result2.Items[0].PurchasePrice);
            Assert.Equal(item2.Quantity, result2.Items[0].Quantity);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var order = new Order(1) { Date = new System.DateTime(2021, 01, 14, 15, 0, 0) };
            var orderRepository = new OrderRepository();
            orderRepository.Save(order);

            //Act
            var result = orderRepository.Load(2);

            //Assert            
            Assert.NotEqual(order, result);
            Assert.Null(result);
        }
    }
}
