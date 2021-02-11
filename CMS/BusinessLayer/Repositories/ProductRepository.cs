using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories
{
    public class ProductRepository
    {
        private InMemoryStorage _storage = new InMemoryStorage();

        public List<Product> Load()
        {
            var result = new List<Product>();
            for (int i=0; i<_storage.Length; i++)
            {
                var newProduct = CreateProduct(_storage[i]);
                result.Add(newProduct);
            }
            return result;
        }
        public Product Load(int id)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (product.Id == id)
                {
                    var newProduct = CreateProduct(_storage[i]);
                    return newProduct;
                }
            }
            return null;
        }

        public bool Save(Product product)
        {
            var newProduct = CreateClone(product);
            _storage.Add(newProduct);
            return true;
        }


        private Product CreateClone(Product product)
        {
            var newProduct = new Product(product.Id) 
                { 
                    Name = product.Name, 
                    Description = product.Description, 
                    Price = product.Price
                };
            return newProduct;
        }
    }
}
