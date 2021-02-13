using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer
{
    public class Product
    {
        public static int InstanceCount { get; set; }
        
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
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }     
        public double? Price
        {
            get { return _price; }
            set { _price = value; }
        }
        

        public Product()
        {

        }
        public Product(int id)
        {
            _id = id;
        }


        public bool Validate()
        {
            var result = true;

            if (String.IsNullOrWhiteSpace(Name))
                result = false;
            if (Price == null)
                result = false;

            return result;
        }
    }
}
