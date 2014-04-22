using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class classListForm : Form
    {
        public classListForm()
        {
            InitializeComponent();
        }

        private void class1ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void classListForm_Load(object sender, EventArgs e)
        {

        }

        private void enterClassesButton_Click(object sender, EventArgs e)
        {
            userForm displayForm = new userForm();
            displayForm.Show();
            this.Hide();
        }
    }
}
