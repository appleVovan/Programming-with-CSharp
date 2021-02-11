using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories
{
    public class OrderRepository
    {
        private InMemoryStorage _storage = new InMemoryStorage();

        public List<Order> Load()
        {
            var result = new List<Order>();
            for (int i=0; i<_storage.Length; i++)
            {
                var newOrder = CreateOrder(_storage[i]);
                result.Add(newOrder);
            }
            return result;
        }
        public Order Load(int id)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (int.Parse(_storage[i]["Id"]) == id)
                {
                    var newOrder = CreateOrder(_storage[i]);
                    return newOrder;
                }
            }
            return null;
        }

        public bool Save(Order order)
        {
            var result = _storage.AddRecord(
                new KeyValuePair<string, string>("Id", order.Id.ToString()),
                new KeyValuePair<string, string>("Date", order.Date.ToString())
            );
            return result;
        }


        private Order CreateOrder(Record record)
        {
            var newOrder = new Order(int.Parse(record["Id"])) 
                { 
                    Date = DateTime.Parse(record["Date"])
                };
            return newOrder;
        }
    }
}
