//CS350 Spring 2014
//CS Connect Group 3
//This program is for testing the opening, reading data, and writing to an Access Database
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
        //this tests the funtion for reading from a database give a field and a table
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

            //desired field Name
            string dBField = "FirstName";
            //desired table Name
            string dBtable = "userInfo";

            //send this command Text and the connection to the function to read 
            //from the database - also for now I need to send the field I am interested in

            string studentNameTest = DatabaseConnector.CommonFunctions.readFromDatabase(connection, dBtable, dBField);

            Assert.AreNotSame(studentNameTest, "Junk1");
            Assert.AreNotSame(studentNameTest, "Junk2");
            Assert.Greater(studentNameTest.Length, 0);

                   
        }

        [Test]
        //this tests reads from a database given a command string - basically the entire select query
        public static void readDataTest()
        {

            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();


            // Create a command

            OleDbCommand cmd = new OleDbCommand();



            // Use the connection that we earlier created

            cmd.Connection = connection;


            //make a string that is the command to try to select something 
            //from the database

            //desired query
            string commandCourse = "SELECT Course from allCourses where Course = '141';";

            //return from query
            List<string> coursesAlreadyInTable = DatabaseConnector.CommonFunctions.readData(connection, commandCourse);

            Assert.IsNotNull(coursesAlreadyInTable);



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

            string command = "INSERT INTO userInfo (Username, Password1, LastName, FirstName) "
                + "VALUES( 'smith_j', 'ps12345', 'John', 'Smith');";


            int nNoAdded = DatabaseConnector.CommonFunctions.writeToDatabase(connection, command);

            Assert.Greater(nNoAdded,0);
        }
            
    }
}