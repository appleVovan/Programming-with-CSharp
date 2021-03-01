using AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities;
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
                result.Add(newOrder);
            }
            return result;
        }
        public Order Load(Guid guid)
        {
            for (int i=0; i<_storage.Length; i++)
            {
                if (Guid.Parse(_storage[i]["Guid"]) == guid)
                {
                    var newOrder = CreateOrder(_storage[i]);
                    return newOrder;
                }
            }
            return null;
        }


        public bool Save(Order order)
        {
            var result = true;
            if (order.HasChanges)
            {
                if (order.IsValid)
                {
                    if (order.IsNew)
                    {
                        result = _storage.AddRecord(
                            new KeyValuePair<string, string>("Guid", order.Guid.ToString()),
                            new KeyValuePair<string, string>("Id", order.Id.ToString()),
                            new KeyValuePair<string, string>("CustomerGuid", order.CustomerGuid.ToString()),
                            new KeyValuePair<string, string>("AddressGuid", order.Address?.Guid.ToString()),
                            new KeyValuePair<string, string>("Date", order.Date.ToString()));
                    }
                    else
                    {
                        result = _storage.UpdateRecord(order.Guid.ToString(),
                            new KeyValuePair<string, string>("Id", order.Id.ToString()),
                            new KeyValuePair<string, string>("CustomerGuid", order.CustomerGuid.ToString()),
                            new KeyValuePair<string, string>("AddressGuid", order.Address?.Guid.ToString()),
                            new KeyValuePair<string, string>("Date", order.Date.ToString()));
                    }
                    SaveItems(order.Items);
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

        private void SaveItems(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                if (item.HasChanges)
                {
                    if (item.IsValid)
                    {
                        if (item.IsNew)
                        {
                            _itemStorage.AddRecord(
                                new KeyValuePair<string, string>("Guid", item.Guid.ToString()),
                                new KeyValuePair<string, string>("OrderGuid", item.OrderGuid.ToString()),
                                new KeyValuePair<string, string>("ProductGuid", item.ProductGuid.ToString()),
                                new KeyValuePair<string, string>("PurchasePrice", item.PurchasePrice.ToString()),
                                new KeyValuePair<string, string>("Quantity", item.Quantity.ToString()));
                        }
                        else
                        {
                            _itemStorage.UpdateRecord(item.Guid.ToString(),
                                new KeyValuePair<string, string>("OrderGuid", item.OrderGuid.ToString()),
                                new KeyValuePair<string, string>("ProductId", item.ProductGuid.ToString()),
                                new KeyValuePair<string, string>("PurchasePrice", item.PurchasePrice.ToString()),
                                new KeyValuePair<string, string>("Quantity", item.Quantity.ToString()));
                        }
                    }
                }
            }
        }      
        
        private Order CreateOrder(Record record)
        {
            Guid guid = Guid.Parse(record["Guid"]);
            var items = LoadItems(guid);
            var address = _addressRepository.Load(Guid.Parse(record["AddressGuid"]));
            var newOrder = new Order(guid, int.Parse(record["Id"]), DateTime.Parse(record["Date"]), items, address, Guid.Parse(record["CustomerGuid"]));        
            return newOrder;
        }    
        private List<OrderItem> LoadItems(Guid orderGuid)
        {
            var result = new List<OrderItem>();
            for (int i=0; i<_itemStorage.Length; i++)
            {
                if (Guid.Parse(_itemStorage[i]["OrderGuid"]) == orderGuid)
                {
                    var newItem = CreateItem(_itemStorage[i]);
                    result.Add(newItem);
                }                
            }
            return result;
        }

        private OrderItem CreateItem(Record record)
        {
            var newOrder = new OrderItem(Guid.Parse(record["Guid"]), Guid.Parse(record["OrderGuid"]), Guid.Parse(record["ProductGuid"]), double.Parse(record["PurchasePrice"]), int.Parse(record["Quantity"]));
            return newOrder;
        }
        
    }
}
