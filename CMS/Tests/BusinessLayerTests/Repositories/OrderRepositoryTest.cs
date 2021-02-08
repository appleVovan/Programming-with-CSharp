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
            var orderRepository = new OrderRepository();
            orderRepository.Save(order);

            //Act
            var result = orderRepository.Load(1);

            //Assert            
            Assert.NotEqual(order, result);
            Assert.Equal(order.Id, result.Id);
            Assert.Equal(order.Date, result.Date);
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
