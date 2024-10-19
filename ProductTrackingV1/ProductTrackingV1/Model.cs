using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
//using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Drawing;
namespace ProductTracking
{
    public class Model
    {
        private formContainer fc;
        private User currentUser;
        private SqlConnection con;
        private ArrayList userList;   //Declare the SqlConnection data connection object as an SqlClient (SQLEXPRESS)
        //DataSet ds;                 //Declare the DataSet object
        //SqlDataAdapter da;   //Declare the DataAdapter object

        public Model()
        {
            userList = new ArrayList();
            con = new SqlConnection();
            con.ConnectionString = "Data Source=3C15-TC\\SQLEXPRESS ;Initial Catalog=ProductTrack;Integrated Security=True";
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

        ~Model()
        {
            con.Close(); ;
        } 

        public formContainer Fc
        {
            get
            {
                return fc;
            }
            set
            {
                fc = value;
            }
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

        public SqlConnection Con
        {
            get
            {
                return con;
            }
            //set
            //{
            //    con = value;
            //}
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
    }
}
