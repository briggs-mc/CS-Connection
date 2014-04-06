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
            
        }



        [Test]
        //test if we can connect to the database
        public static void connectToDatabaseTest()
        {
            
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            Assert.AreEqual(connection.State,ConnectionState.Open);

            connection.Close();

        }

        [Test]
        public static void readFromDatabaseTest()
        {
             
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();


            // Create a command

            OleDbCommand cmd = new OleDbCommand();



            // Use the connection that we earlier created

            cmd.Connection = connection;


            //make a string that is the command to try to select something 
            //from the database

            string command = "Select StudentName FROM userInfo";
            string commandPiece = "StudentName";

            //send this command Text and the connection to the function to read 
            //from the database - also for now I need to send the field I am interested in

            string studentNameTest =  DatabaseConnector.CommonFunctions.readFromDatabase(connection, command, commandPiece);

            Assert.AreNotSame(studentNameTest, "Junk1");
            Assert.AreNotSame(studentNameTest, "Junk2");
            Assert.Greater(studentNameTest.Length, 0);

                   
        }

        [Test]
        public static void writeToDatabaseTest()
        {
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            // Create a command

            OleDbCommand cmd = new OleDbCommand();

            // Use the connection that was passed in

            cmd.Connection = connection;

            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            //the write command text

            string command = "INSERT INTO userInfo (Username, Password1, StudentID, StudentName, Class1, Class2, Class3, Class4, Class5, Class6) "
                + "VALUES( 'smith_j', 'ps12345', '54321', 'John Smith', 'CS142', 'CS385', 'CS131', 'CS123', 'CS234', 'CS567');";


            int nNoAdded = DatabaseConnector.CommonFunctions.writeToDatabase(connection, command);

            Assert.Greater(nNoAdded,0);
        }
            
    }
}