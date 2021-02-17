using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public class Order : EntityBase
    {
        private static int InstanceCount;

        private int _id;
        private DateTime? _date;
        private List<OrderItem> _items;
        private Address _address;
        private int _customerId;


        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                HasChanges = true;
            }
        }
        public List<OrderItem> Items
        {
            get
            {
                return _items;
            }
        }
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                HasChanges = true;
            }
        }
        public int CustomerId
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
                HasChanges = true;
            }
        }


        public Order()
        {
            _items = new List<OrderItem>();
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
        }
        public Order(int id, DateTime date, List<OrderItem> items, Address address, int customerId)
        {
            _id = id;
            _date = date;
            _items = items;
            _address = address;
            _customerId = customerId;
        }


        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (Date == null)
                result = false;
            if (Items == null || Items.Count == 0)
                result = false;
            if (Address == null)
                result = false;
            if (CustomerId <= 0)
                result = false;

            return result;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}";
        }
    }
}
