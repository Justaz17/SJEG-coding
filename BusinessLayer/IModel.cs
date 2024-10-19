using System;
namespace BusinessLayer
{
    public interface IModel
    {
        bool addNewUser(string name, string email, string password, string userType);
        BusinessEntities.User CurrentUser { get; set; }
        DataAccessLayer.IDataLayer DataLayer { get; set; }
        string getUserTypeForCurrentuser();
        bool login(string name, string password);
        void tearDown();
        System.Collections.ArrayList UserList { get; }
    }
}
