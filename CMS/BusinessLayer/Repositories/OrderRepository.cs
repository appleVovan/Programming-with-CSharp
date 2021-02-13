using AR.ProgrammingWithCSharp.CMS.DataAccessLayer;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Repositories
{
    public class OrderRepository
    {
        private InMemoryStorage _storage = new InMemoryStorage();
        private InMemoryStorage _itemStorage = new InMemoryStorage();

        private AddressRepository _addressRepository;


        public OrderRepository()
        {
            _addressRepository = new AddressRepository();
        }
        public OrderRepository(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public List<Order> Load()
        {
            var result = new List<Order>();
            for (int i=0; i<_storage.Length; i++)
            {
                var newOrder = CreateOrder(_storage[i]);
                newOrder.Items = LoadItems(newOrder.Id);
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
                    newOrder.Items = LoadItems(newOrder.Id);
                    return newOrder;
                }
            }
            return null;
        }

        private List<OrderItem> LoadItems(int orderId)
        {
            var result = new List<OrderItem>();
            for (int i=0; i<_itemStorage.Length; i++)
            {
                if (int.Parse(_itemStorage[i]["OrderId"]) == orderId)
                {
                    var newItem = CreateItem(_itemStorage[i]);
                    result.Add(newItem);
                }                
            }
            return result;
        }

        public bool Save(Order order)
        {
            var result = _storage.AddRecord(
                new KeyValuePair<string, string>("Id", order.Id.ToString()),
                new KeyValuePair<string, string>("CustomerId", order.CustomerId.ToString()),
                new KeyValuePair<string, string>("AddressId", order.Address?.Id.ToString()),
                new KeyValuePair<string, string>("Date", order.Date.ToString())
            );
            SaveItems(order.Items);
            return result;
        }

        private void SaveItems(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                _itemStorage.AddRecord(
                        new KeyValuePair<string, string>("Id", item.Id.ToString()),
                        new KeyValuePair<string, string>("OrderId", item.OrderId.ToString()),
                        new KeyValuePair<string, string>("ProductId", item.ProductId.ToString()),
                        new KeyValuePair<string, string>("PurchasePrice", item.PurchasePrice.ToString()),
                        new KeyValuePair<string, string>("Quantity", item.Quantity.ToString())
                    );
            }
        }      
        
        private Order CreateOrder(Record record)
        {
            var newOrder = new Order(int.Parse(record["Id"])) 
                { 
                    Date = DateTime.Parse(record["Date"]),
                    CustomerId = int.Parse(record["CustomerId"])
                };        
            newOrder.Address = _addressRepository.Load(int.Parse(record["AddressId"]));
            return newOrder;
        }        

        private OrderItem CreateItem(Record record)
        {
            var newOrder = new OrderItem(int.Parse(record["Id"]), int.Parse(record["OrderId"])) 
                { 
                    ProductId = int.Parse(record["ProductId"]),
                    PurchasePrice = double.Parse(record["PurchasePrice"]),
                    Quantity = int.Parse(record["Quantity"]),
                };
            return newOrder;
        }
    }
}
