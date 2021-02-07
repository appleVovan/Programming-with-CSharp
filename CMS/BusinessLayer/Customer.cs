using System;

namespace AR.ProgrammingWithCSharp.CMS.BusinessLayer
{
    public class Customer
    {
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
            get { return _lastName; }
            set { _lastName = value; }
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
                return LastName + "," + FirstName;
            }
        }

    }
}
