using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories
{
    public class AddressRepository
    {
        private InMemoryStorage _storage = new InMemoryStorage();


        public List<Address> Load()
        {
            var result = new List<Address>();
            for (int i=0; i<_storage.Length; i++)
            {
                var newAddress = CreateAddress(_storage[i]);
                result.Add(newAddress);
            }
            return result;
        }
        public Address Load(Guid guid)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (Guid.Parse(_storage[i]["Guid"]) == guid)
                {
                    var newAddress = CreateAddress(_storage[i]);
                    return newAddress;
                }
            }
            return null;
        }

        public List<Address> Load(List<Guid> guids)
        {
            var result = new List<Address>();
            for (int i=0; i<_storage.Length; i++)
            {
                if (guids.Contains(Guid.Parse(_storage[i]["Guid"])))
                {
                    var newAddress = CreateAddress(_storage[i]);
                    result.Add(newAddress);
                }
            }
            return result;
        }

        public bool Save(Address address)
        {
            var result = true;
            if (address.HasChanges)
            {
                if (address.IsValid)
                {
                    if (address.IsNew)
                    {
                        result = _storage.AddRecord(
                            new KeyValuePair<string, string>("Guid", address.Guid.ToString()),
                            new KeyValuePair<string, string>("StreetLine1", address.StreetLine1),
                            new KeyValuePair<string, string>("StreetLine2", address.StreetLine2),
                            new KeyValuePair<string, string>("City", address.City),
                            new KeyValuePair<string, string>("StateOrRegion", address.StateOrRegion),
                            new KeyValuePair<string, string>("Country", address.Country),
                            new KeyValuePair<string, string>("Code", address.Code),
                            new KeyValuePair<string, string>("Type", address.Type.ToString()));
                    }
                    else
                    {
                        result = _storage.UpdateRecord(address.Guid.ToString(),
                            new KeyValuePair<string, string>("StreetLine1", address.StreetLine1),
                            new KeyValuePair<string, string>("StreetLine2", address.StreetLine2),
                            new KeyValuePair<string, string>("City", address.City),
                            new KeyValuePair<string, string>("StateOrRegion", address.StateOrRegion),
                            new KeyValuePair<string, string>("Country", address.Country),
                            new KeyValuePair<string, string>("Code", address.Code),
                            new KeyValuePair<string, string>("Type", address.Type.ToString()));
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

        private Address CreateAddress(Record record)
        {
            var newAddress = new Address(Guid.Parse(record["Guid"]), int.Parse(record["Type"]), record["StreetLine1"], 
                record["StreetLine2"], record["City"], record["StateOrRegion"], record["Country"], record["Code"]);
            return newAddress;
        }
    }
}
