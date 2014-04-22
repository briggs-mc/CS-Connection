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
    public partial class userForm : Form
    {
        bool buttonWasClicked = false;
      
        public userForm()
        {
            InitializeComponent();
        }
            
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            chatroomListbox.Items.Add(userEnteredTextbox.Text);
            Client.sendMessageUI(Client.serverTCP, userEnteredTextbox.Text);
            userEnteredTextbox.Clear();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            const string EXIT_MESSAGE = "Exit";
            classListForm displayForm = new classListForm();
            Client.sendMessageUI(Client.serverTCP, EXIT_MESSAGE);
            chatroomListbox.Items.Clear();
            chatroomListbox.Items.Add("You have disconnected from the server");
           // displayForm.Show();
           // this.Hide();
        }

        public string readUserInput()
        {
            return userEnteredTextbox.Text;
        }

        private void userEnteredTextbox_TextChanged(object sender, EventArgs e)
        {
            int messageLength = userEnteredTextbox.Text.Length;
            string message = userEnteredTextbox.Text;

        }

        private void sendButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //chatroomListbox.Items.Add(userEnteredTextbox.Text);
                //Client.sendMessageUI(Client.serverTCP, userEnteredTextbox.Text);
                //userEnteredTextbox.Clear();
            }
        }



    }
}
