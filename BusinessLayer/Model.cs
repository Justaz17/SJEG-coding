using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessEntities;

namespace BusinessLayer
{
    public class Model : IModel
    {
        #region Static Attributes
        private static IModel modelSingletonInstance;  // Model object is a singleton so only one instance allowed
        static readonly object padlock = new object(); // Need this for thread safety on the Model singleton creation. ie in GetInstance () method
        #endregion
        #region Instance Attribures
        private IDataLayer dataLayer;  
        private User currentUser;
        private ArrayList userList;   
        #endregion
        #region Instance Properties
        public IDataLayer DataLayer
        {
            get { return dataLayer; }
            set { dataLayer = value; }
        }
        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
            }
        }


        public ArrayList UserList
        {
            get
            {
                return userList;
            }
            //set
            //{
            //}
        }
        #endregion

        #region Constructors/Destructors
        public static IModel GetInstance(IDataLayer _DataLayer) // With Singleton pattern this method is used rather than constructor
        {
            lock (padlock) //   only one thread can entry this block of code
            {
                if (modelSingletonInstance == null)
                {
                    modelSingletonInstance = new Model( _DataLayer);
                }
                return modelSingletonInstance;
            }
        }
        private Model(IDataLayer _DataLayer)  // The constructor is private as its a singleton and I only allow one instance which is created with the GetInstance() method
        {
            userList = new ArrayList();
            dataLayer = _DataLayer;
            userList = dataLayer.GetAllUsers(); // setup Models userList so we can login
        }

        ~Model()
        {
            tearDown();
        }
        #endregion
        public Boolean login(String name, String password)
        {
            
            foreach (User user in userList)
            {
                if (name == user.Name && password == user.Password)
                {
                  
                    CurrentUser=user;
                    return true;
                }
            }
            return false;
        }
        public Boolean addNewUser(string name,string email, string password, string userType)
        {
            try
            {
               
                // need some code to avoid dulicate usernames
                // maybe add some logic (busiess rules) about password policy
          //      IUser user = new User(name, password, userType); // Construct a User Object
                IUser user = UserFactory.GetUser(name, email, password, userType);   // Using a Factory to create the user entity object. ie seperating object creation from business logic
                UserList.Add(user);                             // Add a reference to the newly created object to the Models UserList
                DataLayer.addNewUserToDB(name,email, password, userType); //Gets the DataLayer to add the new user to the DB. 
                return true;
            }
                catch (System.Exception excep)
            {
                return false;
            }
 
 
           
    
    }

        public String getUserTypeForCurrentuser()
        {
            return currentUser.UserType;
        }


 
        public void tearDown()
        {
            DataLayer.closeConnection();
        }
    }
}
