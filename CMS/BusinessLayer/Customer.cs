using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer
{
    public class Customer
    {
        public static int InstanceCount { get; set; }

        private int _id;
        private string _lastName;
        private string _firstName;
        private string _email;
        private List<Address> _addresses;
        private int _type;


        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }     
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string FullName
        {
            get
            {
                var result = LastName;
                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    if (!String.IsNullOrWhiteSpace(LastName))
                    {
                        result += ", ";
                    }
                    result += FirstName;
                }
                return result;
            }
        }        
        public List<Address> Addresses 
        { 
            get 
            { 
                return _addresses;
            }
            set
            { 
                _addresses = value; 
            }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public Customer()
        {
            _addresses = new List<Address>();
        }
        public Customer(int id) : this()
        {
            _id = id;
        }
        

        public bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(LastName))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;

            return result;
        }
    }
}
