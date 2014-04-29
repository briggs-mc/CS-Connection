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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Form userFor = new Form();
            //MainForm userForm = new MainForm();
            //userFor.Show();
            //userForm.ShowDialog();
            classListForm displayForm = new classListForm();
            displayForm.Show();
            this.Hide();

            
        


        }

      
        private void forgotPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // switch databases from user entered password to ID
        }
    }
}
