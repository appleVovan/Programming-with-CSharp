using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
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
                if (order.Id == id)
                {
                    var newOrder = CreateOrder(_storage[i]);
                    return newOrder;
                }
            }
            return null;
        }

        public bool Save(Order order)
        {
            var newOrder = CreateClone(order);
            _storage.Add(newOrder);
            return true;
        }


        private Order CreateClone(Order order)
        {
            var newOrder = new Order(order.Id) 
                { 
                    Date = order.Date
                };
            return newOrder;
        }
    }
}
