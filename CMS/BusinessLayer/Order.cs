using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer
{
    public class Order
    {
        public static int InstanceCount { get; set; }

        
        private int _id;
        private DateTime? _date;


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
        

        public Order()
        {

        }
        public Order(int id)
        {
            _id = id;
        }


        public List<Order> Load()
        {
            return new List<Order>();
        }
        public Order Load(int id)
        {
            return new Order();
        }

        public bool Save()
        {
            return true;
        }

        public bool Validate()
        {
            var result = true;

            if (Date == null)
                result = false;

            return result;
        }
    }
}
