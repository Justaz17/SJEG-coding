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
    public partial class formOperator : Form
    {
        private formContainer fc;
        private Model model;
        public formOperator(formContainer parent, Model model)
        {
            InitializeComponent();
            MdiParent = parent;
            fc = parent;
            this.model = model;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (model.Con.State.ToString() == "Open")
                model.Con.Close();
            Application.Exit();
        }
    }
}
