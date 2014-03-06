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
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            loginForm displayForm = new loginForm();
            displayForm.Show();
            this.Hide();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            registerForm displayForm = new registerForm();
            displayForm.Show();
            this.Hide();
        }
    }
}
