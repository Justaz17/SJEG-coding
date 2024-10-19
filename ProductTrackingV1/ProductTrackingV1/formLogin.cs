using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProductTracking
{
    
    public partial class formLogin : Form
    {
        private Model model;
        DataSet ds;                 //Declare the DataSet object
        SqlDataAdapter da;   //Declare the DataAdapter object
        int maxRows;
        SqlCommandBuilder cb;
    
        public formLogin(Model model)
        {
            InitializeComponent();
            this.model = model;
            try
            {
                ds = new DataSet();
                string sql = "SELECT * From Users";
                da = new SqlDataAdapter(sql, model.Con);
                cb = new SqlCommandBuilder(da);  //Generates
                da.Fill(ds, "UsersData");
                maxRows = ds.Tables["UsersData"].Rows.Count;
                for (int i = 0; i < maxRows; i++)
                {
                    DataRow dRow = ds.Tables["UsersData"].Rows[i];
                    User user = new User(dRow.ItemArray.GetValue(0).ToString(),
                                                        dRow.ItemArray.GetValue(1).ToString(),
                                                        dRow.ItemArray.GetValue(2).ToString());
                    model.UserList.Add(user);

                    textBoxName.Select();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (model.Con.State.ToString() == "Open")
                    model.Con.Close();
                Application.Exit();
                //Environment.Exit(0); //Force the application to close
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if ( model.Con.State.ToString() == "Open") 
                model.Con.Close();
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool validUser = false;
            foreach (User user in model.UserList)
            {
                if (textBoxName.Text == user.Name && textBoxPassword.Text == user.Password)
                {
                    validUser = true;
                    model.CurrentUser = user;
                    break;
                }
            }
            if (validUser)
                Close();
            else
            {
                MessageBox.Show("Invalid name or password");
                textBoxName.Text = "";
                textBoxPassword.Text = "";
                textBoxName.Select();
            }
        }
    }
}
