using AR.ProgrammingWithCSharp.CMS.Common;
using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer.Entities
{
    public class Product : EntityBase
    {
        private static int InstanceCount;
        
        private int _id;
        private string _name;
        private string _description;
        private double? _price;


        public int Id
        {
            get { return _id; }
            private set { _id = value; }
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
            InstanceCount += 1;
            _id = InstanceCount;
        }
        public Product(int id, string name, string description, double price)
        {
            _id = id;
            _name = name;
            _description = description;
            _price = price;
        }


        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (Price == null)
                result = false;

            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
