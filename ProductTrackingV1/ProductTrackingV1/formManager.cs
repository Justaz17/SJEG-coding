using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductTracking
{
    public partial class formManager : Form
    {
        private formContainer fc;
        private Model model;
    
        public formManager(formContainer parent, Model model)
        {
            InitializeComponent();
            MdiParent = parent;
            fc = parent;
            this.model = model;
        }

       
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if ( model.Con.State.ToString() == "Open" )
                model.Con.Close();
            Application.Exit();
        }

        private void formManager_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            formAddUser form = new formAddUser(fc,  model);
            //form.Show();
            form.Dock = DockStyle.Fill;

            form.Show();
            //fc.WindowState = FormWindowState.Maximized;
           
        }
    }
}
