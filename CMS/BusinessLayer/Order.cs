using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer
{
    public class Order
    {
        public static int InstanceCount { get; set; }
        
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
            get { return _date; }
            set { _date = value; }
        }
        public List<OrderItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }
        

        public Order()
        {
            _items = new List<OrderItem>();
        }
        public Order(int id) : this()
        {
            _id = id;
        }


        public bool Validate()
        {
            var result = true;

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
    }
}
