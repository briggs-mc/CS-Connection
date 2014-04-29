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
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Takes the user to the classList form so they can pick a list of classes to login to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerButton_Click(object sender, EventArgs e)
        {
            classListForm displayForm = new classListForm();
            displayForm.Show();
            this.Hide();
        }
    }
}
