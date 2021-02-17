using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
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
            var result = true;
            if (customer.HasChanges)
            {
                if (customer.IsValid)
                {
                    if (customer.IsNew)
                    {
                        result = _storage.AddRecord(
                            new KeyValuePair<string, string>("Id", customer.Id.ToString()),
                            new KeyValuePair<string, string>("FirstName", customer.FirstName),
                            new KeyValuePair<string, string>("LastName", customer.LastName),
                            new KeyValuePair<string, string>("Email", customer.Email),
                            new KeyValuePair<string, string>("Type", customer.Type.ToString()));
                    }
                    else
                    {
                        result = _storage.UpdateRecord(customer.Id.ToString(),
                            new KeyValuePair<string, string>("FirstName", customer.FirstName),
                            new KeyValuePair<string, string>("LastName", customer.LastName),
                            new KeyValuePair<string, string>("Email", customer.Email),
                            new KeyValuePair<string, string>("Type", customer.Type.ToString()));
                        _customerToAddressStorage.RemoveAllMatchingRecords("CustomerId", customer.Id.ToString());
                    }
                    foreach (var address in customer.Addresses)
                    {
                        _customerToAddressStorage.AddRecord(
                            new KeyValuePair<string, string>("CustomerId", customer.Id.ToString()), 
                            new KeyValuePair<string, string>("AddressId", address.Id.ToString()));
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

        private Customer CreateCustomer(Record record)
        {
            int id = int.Parse(record["Id"]);
            var addresses = LoadAddresses(id);
            var newCustomer = new Customer(id, record["LastName"], record["FirstName"], record["Email"], addresses, int.Parse(record["Type"]));
            return newCustomer;
        }

        private List<Address> LoadAddresses(int customerId)
        {
            var addressIds = new List<int>();
            for (int i=0; i<_customerToAddressStorage.Length; i++)
            {
                if (int.Parse(_customerToAddressStorage[i]["CustomerId"]) == customerId)
                {
                    addressIds.Add(int.Parse(_customerToAddressStorage[i]["AddressId"]));
                }                
            }
            return _addressRepository.Load(addressIds);
        }
    }
}
