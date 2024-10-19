using System;
namespace DataAccessLayer
{
    public interface IDataLayer
    {
        void addNewUserToDB(string name,string email, string password, string userType);
        void closeConnection();
        System.Collections.ArrayList GetAllUsers();
        System.Data.SqlClient.SqlConnection getConnection();
        void openConnection();
    }
}
