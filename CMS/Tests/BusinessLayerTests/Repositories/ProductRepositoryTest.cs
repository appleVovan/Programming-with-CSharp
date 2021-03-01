using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.BusinessLayer.Repositories
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void SaveValidTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };

            //Act
            var result = productRepository.Save(product);

            //Assert            
            Assert.True(result);
        }

        [Fact]
        public void SaveInValidTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench" };

            //Act
            var result = productRepository.Save(product);

            //Assert            
            Assert.False(result);
        }

        [Fact]
        public void SaveNoChangesTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product();

            //Act
            var result = productRepository.Save(product);

            //Assert            
            Assert.False(result);
        }


        [Fact]
        public void SaveLoadTwiceWithChangesTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            productRepository.Save(product);
            var loadedProduct = productRepository.Load(product.Guid);
            loadedProduct.Description = "Misc";

            //Act
            var saveResult = productRepository.Save(loadedProduct);
            var result = productRepository.Load(loadedProduct.Guid);

            //Assert            
            Assert.True(saveResult);
            Assert.NotEqual(product, loadedProduct);
            Assert.NotEqual(loadedProduct, result);
            Assert.NotEqual(product, result);
            Assert.Equal(product.Guid, loadedProduct.Guid);
            Assert.Equal(product.Guid, result.Guid);
            Assert.NotEqual(product.Description, loadedProduct.Description);
            Assert.Equal(loadedProduct.Description, result.Description);
        }

        [Fact]
        public void SaveLoadTwiceNoChangesTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            productRepository.Save(product);
            var loadedProduct = productRepository.Load(product.Guid);

            //Act
            var saveResult = productRepository.Save(loadedProduct);
            var result = productRepository.Load(loadedProduct.Guid);

            //Assert            
            Assert.False(saveResult);
            Assert.NotEqual(product, loadedProduct);
            Assert.NotEqual(loadedProduct, result);
            Assert.NotEqual(product, result);
            Assert.Equal(product.Guid, loadedProduct.Guid);
            Assert.Equal(product.Guid, result.Guid);
            Assert.Equal(product.Description, loadedProduct.Description);
            Assert.Equal(loadedProduct.Description, result.Description);
        }

        [Fact]
        public void LoadValidTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };
            var product2 = new Product() { Name = "Balthazar Vinyl", Description = "Thin Walls", Price = 60.0 };

            productRepository.Save(product);
            productRepository.Save(product2);

            //Act
            var result = productRepository.Load(product.Guid);
            var result2 = productRepository.Load(product2.Guid);

            //Assert            
            Assert.NotEqual(product, result);
            Assert.Equal(product.Guid, result.Guid);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);

            Assert.NotEqual(product2, result2);
            Assert.Equal(product2.Guid, result2.Guid);
            Assert.Equal(product2.Name, result2.Name);
            Assert.Equal(product2.Description, result2.Description);
            Assert.Equal(product2.Price, result2.Price);
        }

        [Fact]
        public void LoadInvalidTest()
        {
            //Arrange
            var productRepository = new ProductRepository();

            var product = new Product() { Name = "Twenty One Pilots Vinyl", Description = "Trench", Price = 50.0 };

            productRepository.Save(product);

            //Act
            var result = productRepository.Load(Guid.NewGuid());

            //Assert            
            Assert.NotEqual(product, result);
            Assert.Null(result);
        }
    }
}
