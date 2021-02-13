using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories
{
    public class CustomerRepository
    {
        private InMemoryStorage _storage = new InMemoryStorage();
        private InMemoryStorage _customerToAddressStorage = new InMemoryStorage();
        
        private AddressRepository _addressRepository;  
        

        public CustomerRepository()
        {
            _addressRepository = new AddressRepository();
        }
        public CustomerRepository(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }



        public List<Customer> Load()
        {
            var result = new List<Customer>();
            for (int i=0; i<_storage.Length; i++)
            {
                var newCustomer = CreateCustomer(_storage[i]);
                newCustomer.Addresses = LoadAddresses(newCustomer.Id);
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
                    newCustomer.Addresses = LoadAddresses(newCustomer.Id);
                    return newCustomer;
                }
            }
            return null;
        }     
        
        private List<Address> LoadAddresses(int customerId)
        {
            var addressIds = new List<int>();
            for (int i=0; i<_customerToAddressStorage.Length; i++)
            {
                if (int.Parse(_customerToAddressStorage[i]["CustomerId"]) == customerId)
                {
                    addressIds.Add(int.Parse(_customerToAddressStorage[i]["CustomerId"]));
                }                
            }
            return _addressRepository.Load(addressIds);
        }

        public bool Save(Customer customer)
        {
            var result = _storage.AddRecord(
                new KeyValuePair<string, string>("Id", customer.Id.ToString()),
                new KeyValuePair<string, string>("FirstName", customer.FirstName),
                new KeyValuePair<string, string>("LastName", customer.LastName),
                new KeyValuePair<string, string>("Email", customer.Email)
            );            

            foreach (var address in customer.Addresses)
            {
                _customerToAddressStorage.AddRecord(
                    new KeyValuePair<string, string>("CustomerId", customer.Id.ToString()), 
                    new KeyValuePair<string, string>("AddressId", address.Id.ToString()));
            }
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
