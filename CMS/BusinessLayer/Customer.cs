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


        public Customer()
        {

        }
        public Customer(int id)
        {
            _id = id;
        }


        public List<Customer> Load()
        {
            return new List<Customer>();
        }
        public Customer Load(int id)
        {
            return new Customer();
        }

        public bool Save()
        {
            return true;
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
