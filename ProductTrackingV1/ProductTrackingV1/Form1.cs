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
    public partial class formContainer : Form
    {
        private Model model;
    
        public formContainer()
        {
            InitializeComponent();
            model = new Model();
            model.Fc = this;
        }

        private void formContainer_Shown(object sender, EventArgs e)
        {
            formLogin formLgn = new formLogin(model);
            formLgn.ShowDialog();

            //MessageBox.Show("Here");
            switch (model.CurrentUser.UserType)
            {
                case "Manager":
                    formManager form1 = new formManager(this, model);
                    //formAddUser form1 = new formAddUser(this, model);
                    this.Text = this.Text + "-Manager";
                    form1.Dock = DockStyle.Fill;
                    form1.Show();
                    break;
                case "Sales":
                    formSales form2 = new formSales(this, model);
                    this.Text = this.Text + "-Sales";
                    form2.Dock = DockStyle.Fill;
                    form2.Show();
                    break;
                case "Production":
                    formOperator form3 = new formOperator(this, model);
                    this.Text = this.Text + "-Production";
                    form3.Dock = DockStyle.Fill;
                    form3.Show();
                    break;
            }


        }
    }
}
