using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductTracking
{
    public class User
    {
        private string name;
        private string password;
        private string userType;

        public User()
        {
            throw new System.NotImplementedException();
        }

        public User(string name, string password, string userType)
        {
            this.name = name;
            this.password = password;
            this.userType = userType;
        }

        public string Name
        {
            get
            {
                return name; ;
            }
            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        public bool IsLogger(string name, string password)
        {
            return (this.name == name && this.password == password);

        }
    }
}
