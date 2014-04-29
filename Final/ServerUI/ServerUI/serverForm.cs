using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ServerUI
{
    public partial class serverForm : Form
    {
        private System.Windows.Forms.Timer timer_;
        public string newMessage = "This message is old";
        public bool messageIsNew = false;
        public serverForm()
        {
            InitializeComponent();
            Text = "Server is in Standby Mode";
            timer_ = new System.Windows.Forms.Timer(); //Timer to refresh listbox to see new message
            timer_.Tick += timer__Tick;
            timer_.Interval = 100; //Timer interval is .1 second
            timer_.Start();
        }

        void timer__Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (messageIsNew == true)
            {
                ClientListBox.Items.Add(newMessage);
                messageIsNew = false;
            }
        }
  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        /// <summary>
        /// Start listener for client to connect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openServerButton_Click(object sender, EventArgs e)
        { 
            Server.serverListenerForClient.Start();
            ParameterizedThreadStart initialize = new ParameterizedThreadStart(Start);
            Thread newThread = new Thread(initialize);
            newThread.Start(this);
            Text = "Server is running.....";
        }

        public void clientConnected(string clientMessage)
        {
            
            ClientListBox.Items.Add(clientMessage);

        }

        private void ClientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        static void Start(object ServerUI)
        {
            serverForm serverScreen = (serverForm)ServerUI;
            Server.Listeners(serverScreen);
        }

        private void closeServerButton_Click(object sender, EventArgs e)
        {
            ClientListBox.Items.Clear();
            ClientListBox.Items.Add("Server is closed");
            Text = "Server is Closed";
        }
    }
}

