using System;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public enum AddressType
    {
        Other = 0,
        Home = 1,
        Work = 2
    }

    public class Address : EntityBase
    {
        private Guid _guid;
        private AddressType _type;
        private string _streetLine1;
        private string _streetLine2;
        private string _city;
        private string _stateOrRegion;
        private string _country;
        private string _code;


        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public AddressType Type
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
        public string StreetLine1
        {
            get
            {
                return _streetLine1;
            }
            set
            {
                _streetLine1 = value;
                HasChanges = true;
            }
        }
        public string StreetLine2
        {
            get
            {
                return _streetLine2;
            }
            set
            {
                _streetLine2 = value;
                HasChanges = true;
            }
        }
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                HasChanges = true;
            }
        }
        public string StateOrRegion
        {
            get
            {
                return _stateOrRegion;
            }
            set
            {
                _stateOrRegion = value;
                HasChanges = true;
            }
        }
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                HasChanges = true;
            }
        }
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                HasChanges = true;
            }
        }


        public Address()
        {
            IsNew = true;
            _guid = Guid.NewGuid();
        }
        public Address(Guid guid, AddressType type, string streetLine1, string streetLine2, string city, string stateOrRegion, string country, string code)
        {
            _guid = guid;
            _type = type;
            _streetLine1 = streetLine1;
            _streetLine2 = streetLine2;
            _city = city;
            _stateOrRegion = stateOrRegion;
            _country = country;
            _code = code;
        }


        public override bool Validate()
        {
            var result = true;

            if (Guid == Guid.Empty)
                result = false;
            if (String.IsNullOrWhiteSpace(StreetLine1))
                result = false;
            if (String.IsNullOrWhiteSpace(City))
                result = false;
            if (String.IsNullOrWhiteSpace(Country))
                result = false;
            if (String.IsNullOrWhiteSpace(Code))
                result = false;

            return result;
        }

        public override string ToString()
        {
            return $"{StreetLine1}, {City}, {StateOrRegion}, {Country}";
        }
    }
}
