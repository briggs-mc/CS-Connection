//CS350 Spring 2014
//CS Connect Group 3
//This program is for testing the opening, reading data, and writing to an Access Database
//adding and removing students and classes from the database

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


namespace CSConnector
{
    [TestFixture]
    public class DatabaseTestClass
    {

        // OleDbConnection connection;
        //I tried but didn't have success setting the connection in the 
        //setup area

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

            Assert.AreEqual(connection.State, ConnectionState.Open);

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
        //this test wtests writing a single entry to the database
        //unlike other adding it does not tests for duplicates
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

            Assert.Greater(nNoAdded, 0);
        }

        //this tests getting a roster from an excel file and adding it to the database
        [Test]
        public static void getRosterTest()
        {

            string excelFileName = "C:\\Users\\briggs_mc\\Desktop\\Final\\databaseConnector\\CS142roosterTest.xlsx";
            FillDatabase myFillDatabase = new FillDatabase();
            myFillDatabase.getRoster(excelFileName);
            Assert.IsNotEmpty(myFillDatabase.course[2]);
        }

        //test writing to the database tables using the function with SELECT queries that limits
        //writing
        [Test]
        public static void rosterToDatabaseTablesTest()
        {
            string excelFileName = "C:\\Users\\briggs_mc\\Desktop\\Final\\databaseConnector\\CS142roosterTest.xlsx";
            FillDatabase myFillDatabase = new FillDatabase();
            myFillDatabase.getRoster(excelFileName);
            myFillDatabase.rosterToDatabaseTables();

            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            string commandCourse = "SELECT Course from allCourses where Course = '" + myFillDatabase.course[2] + "';";

            //returns list of courses that matches - should be either course name or nothing?
            List<string> coursesAlreadyInTable = DatabaseConnector.CommonFunctions.readData(connection, commandCourse);
            bool inTable = coursesAlreadyInTable.Any();
            //   Assert.IsTrue(inTable);

        }

        //test checking professor credentials 
        [Test]
        public static void checkProfCredentialsTest()
        {

            string usernameProf = "ribler_r" + "@lynchburg.edu";
            string passwordProf = "randy";
            //Post to DataBase
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //make the query string to see if there is a match with the info from the login form
            string checkProfCredentialsQueryText = "select count(*) from professors where Username = '" + usernameProf + "' and Password = '" + passwordProf + "';";

            //run the query and get back the number of rows that match the query
            int noRowMatchingProf = DatabaseConnector.CommonFunctions.noRowsContainingInfo(connection, checkProfCredentialsQueryText);

            //check if the number of rows is >0
            Assert.GreaterOrEqual(noRowMatchingProf, 1);
        }

        //test professor entering a single student
        //for some reason this test doesn't always work the first time
        [Test]
        public static void addSingleStudentTest()
        {
            // Declare and set array element values 

            string[] classIDIn = new string[3];
            string[] studentIDIn = new string[3];
            string[] lastNameIn = new string[3];
            string[] firstNameIn = new string[3];
            string[] emailIn = new string[3];

            //to match the first data field when the data is read from excel, set
            //element 2 - just add as a string
            classIDIn[2] = "250";
            studentIDIn[2] = "54545";
            lastNameIn[2] = "Micheals";
            firstNameIn[2] = "Mary";
            emailIn[2] = "michaels_m@lynchburg.edu";

            //make an instance of myFillDatabase
            FillDatabase myFillDatabase = new FillDatabase();
            //since we are not using an excel file we have to set the fields
            myFillDatabase.setUserInfo(classIDIn, studentIDIn, lastNameIn, firstNameIn, emailIn);
            //send the info to the database
            myFillDatabase.rosterToDatabaseTables();


            //check it
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //make the query string to see if there is a match with the info from the login form
            //string checkStudentEnteredQueryText = "select count(*) from classesTaking where Username = '" + emailIn[2] + "' and Course = '" + classIDIn[2] + "';";
            string checkStudentEnteredQueryText = "select count(*) from userInfo where Username = '" + emailIn[2] + "';";
            int noRowEnteredStudent = 100;
            //run the query and get back the number of rows that match the query
            noRowEnteredStudent = DatabaseConnector.CommonFunctions.noRowsContainingInfo(connection, checkStudentEnteredQueryText);

           
            //check if the number of rows is >0
            Assert.GreaterOrEqual(noRowEnteredStudent, 1);
        }

        //test professor deleting a student from a class
        [Test]
        public static void deleteStudentFromAClassTest()
        {
            //First we need to add the student so that it is there ot be deleted
            //since we cannot rely anything else
            // Declare and set array element values 

            string[] classIDIn = new string[3];
            string[] studentIDIn = new string[3];
            string[] lastNameIn = new string[3];
            string[] firstNameIn = new string[3];
            string[] emailIn = new string[3];

            //to match the first data field when the data is read from excel, set
            //element 2 - just add as a string
            classIDIn[2] = "235";
            studentIDIn[2] = "54321";
            lastNameIn[2] = "Smithe";
            firstNameIn[2] = "Joseph";
            emailIn[2] = "smithe_j@lynchburg.edu";

            //make an instance of myFillDatabase
            FillDatabase myFillDatabase = new FillDatabase();
            //since we are not using an excel file we have to set the fields
            myFillDatabase.setUserInfo(classIDIn, studentIDIn, lastNameIn, firstNameIn, emailIn);
            //send the info to the database
            myFillDatabase.rosterToDatabaseTables();

            //now delete the student
            myFillDatabase.deleteStudentFromACourse("smithe_j@lynchburg.edu", "235");

            //check it
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //make the query string to see if there is a match with the info from the login form
            string checkStudentDeletedQueryText = "select count(*) from classesTaking where Username = '" + emailIn[2] + "' and Course = '" + classIDIn[2] + "';";

            //run the query and get back the number of rows that match the query
            int noRowEnteredStudent = DatabaseConnector.CommonFunctions.noRowsContainingInfo(connection, checkStudentDeletedQueryText);

            //check if the number of rows is 0
            Assert.AreEqual(noRowEnteredStudent, 0);

        }

        //test professor deleting a student from all classes
        [Test]
        public static void deleteStudentFromAllClassesTest()
        {
            //First we need to add the student so that it is there ot be deleted
            //since we cannot rely anything else
            // Declare and set array element values 

            string[] classIDIn = new string[3];
            string[] studentIDIn = new string[3];
            string[] lastNameIn = new string[3];
            string[] firstNameIn = new string[3];
            string[] emailIn = new string[3];

            //to match the first data field when the data is read from excel, set
            //element 2 - just add as a string
            classIDIn[2] = "385";
            studentIDIn[2] = "111111";
            lastNameIn[2] = "Johnson";
            firstNameIn[2] = "Demarcus";
            emailIn[2] = "johnson_d@lynchburg.edu";

            //make an instance of myFillDatabase
            FillDatabase myFillDatabase = new FillDatabase();
            //since we are not using an excel file we have to set the fields
            myFillDatabase.setUserInfo(classIDIn, studentIDIn, lastNameIn, firstNameIn, emailIn);
            //send the info to the database
            myFillDatabase.rosterToDatabaseTables();

            //now delete the student
            myFillDatabase.deleteStudentFromAllCourses("johnson_d@lynchburg.edu");

            //check it
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //make the query string to see if there is a match with the info from the login form
            string checkStudentDeletedQueryText = "select count(*) from classesTaking where Username = '" + emailIn[2] + "' and Course = '" + classIDIn[2] + "';";

            //run the query and get back the number of rows that match the query
            int noRowEnteredStudent = DatabaseConnector.CommonFunctions.noRowsContainingInfo(connection, checkStudentDeletedQueryText);

            //check if the number of rows is 0
            Assert.AreEqual(noRowEnteredStudent, 0);

        }
    }
}

