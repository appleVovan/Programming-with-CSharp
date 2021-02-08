using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories
{
    public class OrderRepository
    {
        private List<Order> _storage = new List<Order>();

        public List<Order> Load()
        {
            var result = new List<Order>();
            foreach (var order in _storage)
            {
                var newOrder = CreateClone(order);
                result.Add(newOrder);
            }
            return result;
        }
        public Order Load(int id)
        {
            foreach (var order in _storage)
            {
                if (order.Id == id)
                {
                    var newOrder = CreateClone(order);
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
