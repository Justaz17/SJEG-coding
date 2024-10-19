using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;

namespace ProductTracking
{
    public partial class formAddUser : Form
    {
        #region Instance Attributes
        IModel Model;
        formContainer fc;
        #endregion 

       #region Constructors
        public formAddUser( formContainer parent, IModel Model)
        {
            InitializeComponent();
            MdiParent = parent;
            fc = parent;
            this.Model = Model;        
        }
       #endregion

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            if (listBoxUserType.SelectedIndex != -1)
            {
                if (Model.addNewUser(textBoxName.Text,"", textBoxPassword.Text, listBoxUserType.SelectedItem.ToString()))
                {
                    MessageBox.Show("User created");
                    textBoxName.Text = "";
                    textBoxPassword.Text = "";
                }
            }
            else
            {
                MessageBox.Show("You must select a user type!");
                textBoxName.Text = "";
                textBoxPassword.Text = "";

            }
        }
    }
}
