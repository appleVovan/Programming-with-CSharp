using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
using System.Collections.Generic;
using System;

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
        public Product Load(Guid guid)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (Guid.Parse(_storage[i]["Guid"]) == guid)
                {
                    var newProduct = CreateProduct(_storage[i]);
                    return newProduct;
                }
            }
            return null;
        }

        public bool Save(Product product)
        {
            var result = true;
            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
                    {
                        result = _storage.AddRecord(
                            new KeyValuePair<string, string>("Guid", product.Guid.ToString()),
                            new KeyValuePair<string, string>("Name", product.Name),
                            new KeyValuePair<string, string>("Description", product.Description),
                            new KeyValuePair<string, string>("Price", product.Price.ToString()));
                    }
                    else
                    {
                        result = _storage.UpdateRecord(product.Guid.ToString(),
                            new KeyValuePair<string, string>("Name", product.Name),
                            new KeyValuePair<string, string>("Description", product.Description),
                            new KeyValuePair<string, string>("Price", product.Price.ToString()));
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        private Product CreateProduct(Record record)
        {
            var newProduct = new Product(Guid.Parse(record["Guid"]), record["Name"], record["Description"], double.Parse(record["Price"]));
            return newProduct;
        }
    }
}
