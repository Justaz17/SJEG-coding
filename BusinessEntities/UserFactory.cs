﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public static class UserFactory // Only concern of factory is to create objects. 
    {
        private static IUser user=null;

        public static IUser GetUser(string name,string email, string password, string userType)
        {
            if (user != null)  // ie is Factory is primed with an object. 
                return user;
            else
                return new User(name,email, password, userType); // Factory coughs up a regular user (for production code) 
        }
        public static void SetUser(IUser aUser)   // This provides a seam in the factory where I can prime the factory with the user it will then cough up. (for test code) 
        {
            user = aUser; 
        }
    }

    }


