using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories
{
    public class CustomerRepository
    {
        private InMemoryStorage _storage = new InMemoryStorage();

        public List<Customer> Load()
        {
            var result = new List<Customer>();
            for (int i=0; i<_storage.Length; i++)
            {
                var newCustomer = CreateCustomer(_storage[i]);
                result.Add(newCustomer);
            }
            return result;
        }
        public Customer Load(int id)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (int.Parse(_storage[i]["Id"]) == id)
                {
                    var newCustomer = CreateCustomer(_storage[i]);
                    return newCustomer;
                }
            }
            return null;
        }

        public bool Save(Customer customer)
        {
            var result = _storage.AddRecord(
                new KeyValuePair<string, string>("Id", customer.Id.ToString()),
                new KeyValuePair<string, string>("FirstName", customer.FirstName),
                new KeyValuePair<string, string>("LastName", customer.LastName),
                new KeyValuePair<string, string>("Email", customer.Email)
            );
            return result;
        }


        private Customer CreateCustomer(Record record)
        {
            var newCustomer = new Customer(int.Parse(record["Id"])) 
                { 
                    LastName = record["LastName"], 
                    FirstName = record["FirstName"], 
                    Email = record["Email"] 
                };
            return newCustomer;
        }
    }
}
