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
                if (int.Parse(_storage[i]["Id"]) == id)
                {
                    var newProduct = CreateProduct(_storage[i]);
                    return newProduct;
                }
            }
            return null;
        }

        public bool Save(Product product)
        {
            var result = _storage.AddRecord(
                new KeyValuePair<string, string>("Id", product.Id.ToString()),
                new KeyValuePair<string, string>("Name", product.Name),
                new KeyValuePair<string, string>("Description", product.Description),
                new KeyValuePair<string, string>("Price", product.Price.ToString())
            );
            return result;
        }

        private Product CreateProduct(Record record)
        {
            var newProduct = new Product(int.Parse(record["Id"])) 
                { 
                    Name = record["Name"], 
                    Description = record["Description"], 
                    Price = double.Parse(record["Price"])
                };
            return newProduct;
        }
    }
}
