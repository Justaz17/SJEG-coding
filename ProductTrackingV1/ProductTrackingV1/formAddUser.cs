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
    public partial class formAddUser : Form
    {
        Model model;
       formContainer fc;
        public formAddUser( formContainer parent, Model model)
        {
            InitializeComponent();
            MdiParent = parent;
            fc = parent;
            this.model = model;
            

           
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            
            User user = new User(textBoxName.Text,
                                                textBoxPassword.Text,
                                                listBoxUserType.SelectedItem.ToString());
            model.UserList.Add(user);
            
            if (model.Con.State.ToString() != "Open")
                model.Con.Open();

            DataSet ds = new DataSet();
            string sql = "SELECT * From Users";
            SqlDataAdapter da = new SqlDataAdapter(sql, model.Con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);  //Generates
            da.Fill(ds, "UsersData");

            DataRow dRow = ds.Tables["UsersData"].NewRow();
            dRow[0] = textBoxName.Text;
            dRow[1] = textBoxPassword.Text;
            dRow[2] = listBoxUserType.SelectedItem.ToString();
                  
            ds.Tables["UsersData"].Rows.Add(dRow);
            da.Update(ds, "UsersData"); 
        }
    }
}
