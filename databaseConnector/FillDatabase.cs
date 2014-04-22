using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Net;


namespace CSConnector
{


    class FillDatabase
    {
        //data members
        private string[] course_;

        public string[] Course_
        {
            get { return course_; }
            set { course_ = value; }
        }
        private string[] studentID;

        public string[] StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        private string[] lastName;

        public string[] LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private string[] firstName;

        public string[] FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string[] email;

        public string[] Email
        {
            get { return email; }
            set { email = value; }
        }

        //read from the excel file and get data that I need
        //will be changed to bring in Excel file from Professor Login
        public void getRooster ()
        {


            //Read required data from Excel Worksheet
            string excelFileName = "C:\\Users\\briggs_mc\\cs350\\CS-connect\\DatabaseConnector\\CS142roosterTest.xlsx";
            Workbook workbook = ExcelReader.ExcelReader.openWorkbook(excelFileName);
            //make arrays for the required fields - we do not want to put in the database private info

            
            //now read for the Excel worksheet and get out the info that we need
            ExcelReader.ExcelReader.readWorksheet(workbook, out course_, out studentID, 
                out lastName, out firstName, out email);
        }

        //Put data into tables as necessary
        public void roosterToDatabaseTables ()
        {
            
            //Post to DataBase
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //Write to the database tables
            //we have three tables - 
            //  userInfo - stores basic data on the user
            //  allCourse - stores all possible courses with a primary key
            //  coursesTaken - list students and the course they are taking - each student may have multiple records

            //first need to take the course and write it into the courses table if it is not already there
            //check if it is there
            //for each read for the excel file all the records will have the same course number, so just pick the first one - [2]
            string commandCourse = "SELECT Course from allCourses where Course = '" + course_[2] + "';";
            
            //returns list of courses that matches - should be either course name or nothing?
            List<string> coursesAlreadyInTable = DatabaseConnector.CommonFunctions.readData(connection, commandCourse);
           
            //if the query returns no records (meaning the course we are looking for is not in the table) add it
            if (!coursesAlreadyInTable.Any())
            {
                string commandCourseInsert = "INSERT INTO allCourses (Course) VALUES ('" + course_[2] + "');";
                int nNoAddedCourse = DatabaseConnector.CommonFunctions.writeToDatabase(connection, commandCourseInsert);
            }

            //now we need to add the students to the userInfo table if they are not already there and 
            //to the classesTaking table


            //the write command text
            //write the command text for multiple rows using only needed fields
            //start with array index 2 - array index 0 is not writen from excel and 1 is used for the headers
            // - this command is for inserting the required fields into the database


            for (int i = 2; i < studentID.Length; ++i)
            {
                //should return one name data or empty list
                //may should change it to just get all the studentIDs first and then search the list
                string lookupStudentIdCommand = "SELECT Username from userInfo where Username = '" + email[i] + "';"; 
                //returns list with studentID or nothing?
                List<string> studentsAlreadyInTable = DatabaseConnector.CommonFunctions.readData(connection, lookupStudentIdCommand);

                int nNoAddedCourse = DatabaseConnector.CommonFunctions.writeToDatabase(connection, lookupStudentIdCommand);
                // if empty add record
                if (!coursesAlreadyInTable.Any())
                {
                    string StudentToUserInfoCommand = "INSERT INTO userInfo (Username, Password1, LastName, FirstName) VALUES ('" + email[i] + "', '" + studentID[i] + "', '" + lastName[i] + "', '" + firstName[i] + "');";

                    int nNoStudentsAdded = DatabaseConnector.CommonFunctions.writeToDatabase(connection, StudentToUserInfoCommand);
                }
                //either way add to classesTaking table
                string StudentClassesTakingCommand = "INSERT INTO classesTaking (Username, Course) VALUES ('" + email[i] + "', '" + course_[i] + "');";

                int nNoAddedClass = DatabaseConnector.CommonFunctions.writeToDatabase(connection, StudentClassesTakingCommand);

            }
        
        }
    }
}
