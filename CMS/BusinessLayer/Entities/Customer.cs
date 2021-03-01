using AR.ProgrammingWithCSharp.CMS.Common;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public enum CustomerType
    {
        Private = 1,
        Business = 2,
        Government = 3,
        Education = 4
    }

    public class Customer : EntityBase, ILoggable
    {
        private Guid _guid;
        private string _lastName;
        private string _firstName;
        private string _email;
        private List<Address> _addresses;
        private CustomerType _type;


        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
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
        public CustomerType Type
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
            _guid = Guid.NewGuid();
            _addresses = new List<Address>();
        }
        public Customer(Guid guid, string lastName, string firstName, string email, List<Address> addresses, CustomerType type)
        {
            _guid = guid;
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
            _addresses = addresses;
            _type = type;
        }


        public override bool Validate()
        {
            var result = true;

            if (Guid == Guid.Empty)
                result = false;
            if (String.IsNullOrWhiteSpace(LastName))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;

            return result;
        }

        public string Log()
        {
            return $"Customer {_guid}: {_lastName}, {_firstName}, Email: {_email}, Status: {State}";
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
