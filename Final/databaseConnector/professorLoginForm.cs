//CS350 Spring 2014
//CS Connect Group 3
//This is the interface for the profoessor to login to manage the databse
//Right now, the this will have to be done from the server
//machine that has the database
//In a perfect world this can be done across the server
//but time ran out and the client never worked right


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;

namespace CSConnector
{
    public partial class ProfessorLogin : Form
    {
        public ProfessorLogin()
        {
            InitializeComponent();
        }

        private void profLoginButton_Click(object sender, EventArgs e)
        {
            //when login in is pushed - send username and password to database
            //get back whether a match is found
            //if match go to next screen
            //if not error message

            string usernameProf = returnProfUsername() + "@lynchburg.edu";
            string passwordProf = returnProfPassword();
            //Post to DataBase
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);
            
            //make the query string to see if there is a match with the info from the login form
            string checkProfCredentialsQueryText = "select count(*) from professors where Username = '" + usernameProf + "' and Password = '" + passwordProf + "';"; 

            //run the query and get back the number of rows that match the query
            int noRowMatchingProf = DatabaseConnector.CommonFunctions.noRowsContainingInfo(connection, checkProfCredentialsQueryText);

            //if we get a return of at least 1 row then creditials match and we can go on to the next screen
            //if not then post a message that username and/or password is incorrect

            if (noRowMatchingProf >= 1)
            {

                //change screens????
                professorModifyData displayForm = new professorModifyData();
                displayForm.Show();
                this.Hide();
       
            }
            else
            {
                //print error message

                profErrorMessage.Text = "Username and/or password incorrect";

            }
        
        
        }

        private void profUsernametextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public string returnProfUsername()
        {
            return profUsernametextBox.Text;
        }

        private void profPasswordtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnProfPassword()
        {
            return profPasswordtextBox.Text;
        }

        private void ProfessorLogin_Load(object sender, EventArgs e)
        {

        }

        

    }
}
