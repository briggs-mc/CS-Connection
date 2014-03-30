using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Net;
using NUnit.Framework;

namespace databaseTest
{
    [TestFixture]
    public class DatabaseTestClass
    {
        [SetUp]
        public void Setup()
        {

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString =

           "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs300\\CS-connect\\databaseConnector\\csconnect.accdb;";
            //string server = "localhost";
            //string database = "csconnect";
            //string uid = "root";
            //string password = "dftMySQLpattok?";
            //string connectionString;
            //connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
            //database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            // connection = new MySqlConnection(connectionString);
        }

        [Test]
        public static void connectToDatabase(OleDbConnection connection)
        {

            connection.Open();

            Assert.IsNotNull(connection.State);

            connection.Close();

            
            //return connection;


        }

        [Test]
        public static void readFromDatabase(OleDbConnection connection)
        {
            connection.Open();


            // Create a command

            OleDbCommand cmd = new OleDbCommand();



            // Use the connection that was passed in

            cmd.Connection = connection;



            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            //get something

            string command = "Select StudentName FROM userInfo";

            Assert.IsNotNull(command);
        }
            
    }
}