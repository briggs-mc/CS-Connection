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

namespace ProfessorLoginForm
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
            bool profCredentialsMatch;
            if (noRowMatchingProf >= 1)
            {
                profCredentialsMatch = true;
                //change screens????
                professorModifyData displayForm = new professorModifyData();
                displayForm.Show();
                this.Hide();
       
            }
            else
            {
                //print error message
                profCredentialsMatch = false;

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
