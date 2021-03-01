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
        public Customer Load(Guid guid)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (Guid.Parse(_storage[i]["Guid"]) == guid)
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
                            new KeyValuePair<string, string>("Guid", customer.Guid.ToString()),
                            new KeyValuePair<string, string>("FirstName", customer.FirstName),
                            new KeyValuePair<string, string>("LastName", customer.LastName),
                            new KeyValuePair<string, string>("Email", customer.Email),
                            new KeyValuePair<string, string>("Type", customer.Type.ToString()));
                    }
                    else
                    {
                        result = _storage.UpdateRecord(customer.Guid.ToString(),
                            new KeyValuePair<string, string>("FirstName", customer.FirstName),
                            new KeyValuePair<string, string>("LastName", customer.LastName),
                            new KeyValuePair<string, string>("Email", customer.Email),
                            new KeyValuePair<string, string>("Type", customer.Type.ToString()));
                        _customerToAddressStorage.RemoveAllMatchingRecords("CustomerGuid", customer.Guid.ToString());
                    }
                    foreach (var address in customer.Addresses)
                    {
                        _customerToAddressStorage.AddRecord(
                            new KeyValuePair<string, string>("CustomerGuid", customer.Guid.ToString()), 
                            new KeyValuePair<string, string>("AddressGuid", address.Guid.ToString()));
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
            Guid guid = Guid.Parse(record["Guid"]);
            var addresses = LoadAddresses(guid);
            var newCustomer = new Customer(guid, record["LastName"], record["FirstName"], record["Email"], addresses, int.Parse(record["Type"]));
            return newCustomer;
        }

        private List<Address> LoadAddresses(Guid customerGuid)
        {
            var addressGuids = new List<Guid>();
            for (int i=0; i<_customerToAddressStorage.Length; i++)
            {
                if (Guid.Parse(_customerToAddressStorage[i]["CustomerGuid"]) == customerGuid)
                {
                    addressGuids.Add(Guid.Parse(_customerToAddressStorage[i]["AddressGuid"]));
                }                
            }
            return _addressRepository.Load(addressGuids);
        }
    }
}
