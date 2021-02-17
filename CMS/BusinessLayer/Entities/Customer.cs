using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public class Customer : EntityBase
    {
        private static int InstanceCount;

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
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                HasChanges = true;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                HasChanges = true;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                HasChanges = true;
            }
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
        }
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                HasChanges = true;
            }
        }


        public Customer()
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
            _addresses = new List<Address>();
        }
        public Customer(int id, string lastName, string firstName, string email, List<Address> addresses, int type)
        {
            _id = id;
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
            _addresses = addresses;
            _type = type;
        }


        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (String.IsNullOrWhiteSpace(LastName))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;

            return result;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
