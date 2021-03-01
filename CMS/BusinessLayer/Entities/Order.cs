using AR.ProgrammingWithCSharp.CMS.Common;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public class Order : EntityBase, ILoggable
    {
        private static int InstanceCount;

        private Guid _guid;
        private int _id;
        private DateTimeOffset? _date;
        private List<OrderItem> _items;
        private Address _address;
        private Guid _customerGuid;

        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public DateTimeOffset? Date
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
        public Guid CustomerGuid
        {
            get
            {
                return _customerGuid;
            }
            set
            {
                _customerGuid = value;
                HasChanges = true;
            }
        }


        public Order()
        {
            _items = new List<OrderItem>();
            IsNew = true;  
            _guid = Guid.NewGuid();
            InstanceCount += 1;
            _id = InstanceCount;
        }
        public Order(Guid guid, int id, DateTimeOffset date, List<OrderItem> items, Address address, Guid customerGuid)
        {
            _guid = guid;
            _id = id;
            _date = date;
            _items = items;
            _address = address;
            _customerGuid = customerGuid;
        }


        public override bool Validate()
        {
            var result = true;

            if (Guid == Guid.Empty)
                result = false;
            if (Id <= 0)
                result = false;
            if (Date == null)
                result = false;
            if (Items == null || Items.Count == 0)
                result = false;
            if (Address == null)
                result = false;
            if (CustomerGuid == Guid.Empty)
                result = false;

            return result;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}";
        }

        public string Log()
        {
            return $"Order {Id}: Date: {Date}, Status: {State}";
        }
    }
}
