using System;

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

    }
}
