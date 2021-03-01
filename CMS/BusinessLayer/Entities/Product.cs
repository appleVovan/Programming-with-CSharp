using AR.ProgrammingWithCSharp.CMS.Common;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public class Product : EntityBase, ILoggable
    {
        private Guid _guid;
        private string _name;
        private string _description;
        private double? _price;


        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public string Name
        {
            get 
            { 
                return _name.InsertSpaces(); 
            }
            set 
            { 
                _name = value; 
                HasChanges = true;
            }
        }
        public string Description
        {
            get 
            { 
                return _description; 
            }
            set 
            { 
                _description = value; 
                HasChanges = true;
            }
        }     
        public double? Price
        {
            get 
            { 
                return _price; 
            }
            set 
            {
                _price = value;
                HasChanges = true;
            }
        }
        

        public Product()
        {
            IsNew = true;
            _guid = Guid.NewGuid();
        }
        public Product(Guid guid, string name, string description, double price)
        {
            _guid = guid;
            _name = name;
            _description = description;
            _price = price;
        }


        public override bool Validate()
        {
            var result = true;

            if (Guid == Guid.Empty)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (Price == null)
                result = false;

            return result;
        }        

        public string Log()
        {
            return $"Customer {_guid}: {_name}, Description: {_description}, Status: {State}";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
