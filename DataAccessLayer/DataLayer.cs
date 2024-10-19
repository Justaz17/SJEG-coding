using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using BusinessEntities;

namespace DataAccessLayer
{
    public class DataLayer : IDataLayer
    {
        #region Instance Attributes
        private SqlConnection con;   // DB Connection
        DataSet ds;                 //Declare the DataSet object
        SqlDataAdapter da;          //Declare the DataAdapter object
        int maxRows;
        SqlCommandBuilder cb;
        #endregion
        #region Static Attributes
        private static IDataLayer dataLayerSingletonInstance;  // DataLayer object is a singleton so only one instance allowed
        static readonly object padlock = new object(); // Need this for thread safety on the DataLayer singleton creation. ie in GetInstance () method
        #endregion
        #region Constructors
        public static IDataLayer GetInstance() // With Singleton pattern this method is used rather than constructor
        {
            lock (padlock) //   only one thread can entry this block of code
            {
                if (dataLayerSingletonInstance == null)
                {
                    dataLayerSingletonInstance = new DataLayer();
                }
                return dataLayerSingletonInstance;
            }
        }
        private DataLayer()  // The constructor is private as its a singleton and I only allow one instance which is created with the GetInstance() method
        {
            openConnection();
        }
        #endregion
        public void openConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-U8TVV9KN ;Initial Catalog=incidentmanagementsystem;Integrated Security=True";
            try
            {
                con.Open();
                //MessageBox.Show("Database Open");
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                Environment.Exit(0); //Force the application to close
            }
        }

        public void closeConnection()
        {
            con.Close();
        }

        public SqlConnection getConnection()
        {
            return con;
        }  

        public ArrayList GetAllUsers()
        {
            ArrayList UserList = new ArrayList() ;
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From employee";
                da = new SqlDataAdapter(sql, con);
                cb = new SqlCommandBuilder(da);  //Generates#
                da.Fill(ds, "UsersData");
                maxRows = ds.Tables["UsersData"].Rows.Count;
                MessageBox.Show(maxRows.ToString());
                for (int i = 0; i < maxRows; i++)
                {

                    DataRow dRow = ds.Tables["UsersData"].Rows[i];
                    MessageBox.Show(dRow.ItemArray.GetValue(1).ToString());
                    IUser user = UserFactory.GetUser(dRow.ItemArray.GetValue(1).ToString(),  // Using a Factory to create the user entity object. ie seperating object creation from business logic
                                                        dRow.ItemArray.GetValue(2).ToString(),
                                                        dRow.ItemArray.GetValue(3).ToString(),
                                                        dRow.ItemArray.GetValue(0).ToString());



                    //IUser user = new User(dRow.ItemArray.GetValue(0).ToString(),
                    //                                    dRow.ItemArray.GetValue(1).ToString(),
                    //                                    dRow.ItemArray.GetValue(2).ToString());


                    UserList.Add(user);
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show("hi");
                MessageBox.Show(excep.Message);
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
            return UserList;
        }
        public void addNewUserToDB(String name,String email, String password, String userType)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "SELECT * From employee";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "UsersData");
                maxRows = ds.Tables["UsersData"].Rows.Count;
                DataRow dRow = ds.Tables["UsersData"].NewRow();
                dRow[1] = name;
                dRow[2] = email;
                dRow[3] = password;
                dRow[4] = userType;
                dRow[5] = maxRows+1;

                ds.Tables["UsersData"].Rows.Add(dRow);
                da.Update(ds, "UsersData"); 
            }
            catch (System.Exception excep)
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }
    }
}
