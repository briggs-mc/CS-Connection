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
      
        // OleDbConnection connection;

        [SetUp]
        public void Setup()
        {

         //   connection = new OleDbConnection();
         //   connection.ConnectionString =

         //  "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs350\\CS-connect\\databaseConnector\\csconnect.accdb;";
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
        public static void connectToDatabase()
        {
            
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString =

           "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs350\\CS-connect\\databaseConnector\\csconnect.accdb;";
            connection.Open();

            Assert.AreEqual(connection.State,ConnectionState.Open);

            connection.Close();

            
            //return connection;


        }

        [Test]
        public static void readFromDatabase()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString =

           "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs350\\CS-connect\\databaseConnector\\csconnect.accdb;";
            connection.Open();


            // Create a command

            OleDbCommand cmd = new OleDbCommand();



            // Use the connection that was passed in

            cmd.Connection = connection;



            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            //get something

            string command = "Select StudentName FROM userInfo";

            cmd.CommandText = command;
     

            OleDbDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    string studentNameTest = (string)reader["StudentName"];
                    Assert.Greater(studentNameTest.Length, 0);

                }

            }
  
            reader.Close();
         
           
        }

        [Test]
        public static void writeToDatabase()
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString =

           "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\briggs_mc\\cs350\\CS-connect\\databaseConnector\\csconnect.accdb;";
            connection.Open();

            // Create a command

            OleDbCommand cmd = new OleDbCommand();

            // Use the connection that was passed in

            cmd.Connection = connection;

            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            //write something

            string command = "INSERT INTO userInfo (Username, Password, StudentID, StudentName, Class1, Class2, Class3, Class4, Class5, Class6) "
                + "VALUES( 'smith_j', 'ps12345', '54321', 'John Smith', 'CS142', 'CS385', 'CS131', 'CS123', 'CS234', 'CS567');";

            //string command = "INSERT INTO userInfo VALUES( 'smith_j', 'ps12345', '54321', 'John Smith', 'CS142', 'CS385', 'CS131', 'CS123','CS345', 'CS234');";
            

            cmd.CommandText = command;

            int nNoAdded = cmd.ExecuteNonQuery();

            Assert.Greater(nNoAdded,0);
        }
            
    }
}