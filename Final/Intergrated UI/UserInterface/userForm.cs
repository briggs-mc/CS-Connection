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
      
        /// <summary>
        /// Starts an insatance of the form.
        /// </summary>
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

        /// <summary>
        /// Sends the message the user types in the textBox to the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendButton_Click(object sender, EventArgs e)
        {
            chatroomListbox.Items.Add(userEnteredTextbox.Text);
            Client.sendMessageUI(Client.serverTCP, userEnteredTextbox.Text);
            userEnteredTextbox.Clear();
        }

        /// <summary>
        /// Logs out of the server and prints a message to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Reads the information to the textbox.
        /// </summary>
        /// <returns></returns>
        public string readUserInput()
        {
            return userEnteredTextbox.Text;
        }

        /// <summary>
        /// Checks and sees if the text box was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
