using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class User : BusinessEntities.IUser
    {
        #region Instance Properties
        private string name;
        private string email;
        private string password;
        private string userType;
        #endregion

        #region Instance Properties
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
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                Email = value;
            }
        }


        #endregion
        #region Constructors
        public User()
        {
            throw new System.NotImplementedException();
        }

        public User(string name,string email, string password, string userType)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.userType = userType;
        }

        #endregion

      
    }
}
