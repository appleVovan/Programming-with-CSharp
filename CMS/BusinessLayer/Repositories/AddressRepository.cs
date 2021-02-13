using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
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
        public Address Load(int id)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (int.Parse(_storage[i]["Id"]) == id)
                {
                    var newAddress = CreateAddress(_storage[i]);
                    return newAddress;
                }
            }
            return null;
        }

        public List<Address> Load(List<int> ids)
        {
            var result = new List<Address>();
            for (int i=0; i<_storage.Length; i++)
            {
                if (ids.Contains(int.Parse(_storage[i]["Id"])))
                {
                    var newAddress = CreateAddress(_storage[i]);
                    result.Add(newAddress);
                }
            }
            return result;
        }

        public bool Save(Address address)
        {
            var result = _storage.AddRecord(
                new KeyValuePair<string, string>("Id", address.Id.ToString()),
                new KeyValuePair<string, string>("StreetLine1", address.StreetLine1),
                new KeyValuePair<string, string>("StreetLine2", address.StreetLine2),
                new KeyValuePair<string, string>("City", address.City),
                new KeyValuePair<string, string>("State", address.State),
                new KeyValuePair<string, string>("Country", address.Country),
                new KeyValuePair<string, string>("Code", address.Code),
                new KeyValuePair<string, string>("Type", address.Type.ToString())
            );
            return result;
        }

        private Address CreateAddress(Record record)
        {
            var newAddress = new Address(int.Parse(record["Id"])) 
                { 
                    StreetLine1 = record["StreetLine1"], 
                    StreetLine2 = record["StreetLine2"], 
                    City = record["City"], 
                    State = record["State"], 
                    Country = record["Country"], 
                    Code = record["Code"], 
                    Type = int.Parse(record["Type"])
                };
            return newAddress;
        }
    }
}
