//CS350 Spring 2014
//CS Connect Group 3
//This class is used to get data to the database, remove data from the database
//and lookup data from the database 



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


    class FillDatabase : IFillDatabase
    {
        //data members and getters for them
        //these are the fields that I am taking from the excel spreadsheet
        //to put in the 
        private string[] course_;

        public string[] course
        {
            get { return course_; }

        }
        private string[] studentID_;

        public string[] studentID
        {
            get { return studentID_; }
        }
        private string[] lastName_;

        public string[] lastName
        {
            get { return lastName_; }
        }

        private string[] firstName_;

        public string[] firstName
        {
            get { return firstName_; }
        }

        private string[] email_;

        public string[] email
        {
          get { return email_; }
        }



        /// <summary>
        /// set the member variables - this is used to set these variables when not set in mass from the excel file
        /// </summary>
        /// <param name="classIDIn"></param>
        /// <param name="studentIDIn"></param>
        /// <param name="lastNameIn"></param>
        /// <param name="firstNameIn"></param>
        /// <param name="emailIn"></param>
        public void setUserInfo(string[] classIDIn, string[] studentIDIn, string[] lastNameIn,
            string[] firstNameIn, string[] emailIn)
        {
            course_    = classIDIn;
            studentID_ = studentIDIn;
            lastName_  = lastNameIn;
            firstName_ = firstNameIn;
            email_     = emailIn;

        }


        /// <summary>
        /// read from the excel file and get data that I need 
        /// will be changed to bring in Excel file from Professor Login
        /// </summary>
        /// <param name="excelFileName"></param>
        public void getRoster(string excelFileName)
        {


            //Read required data from Excel Worksheet
            //string excelFileName = "C:\\Users\\briggs_mc\\cs350\\CS-connect\\DatabaseConnector\\CS142roosterTest.xlsx";
            Workbook workbook = ExcelReader.openWorkbook(excelFileName);
            //make arrays for the required fields - we do not want to put in the database private info

            
            //now read for the Excel worksheet and get out the info that we need
            ExcelReader.readWorksheet(workbook, out course_, out studentID_, 
                out lastName_, out firstName_, out email_);
        }

        /// <summary>
        /// Put data from roster or individually entered student into tables as necessary
        /// </summary>
        public void rosterToDatabaseTables ()
        {
            
            //Post to DataBase
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //Write to the database tables
            //we have three tables for storing student information - 
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
                if (!studentsAlreadyInTable.Any())
                {
                    string StudentToUserInfoCommand = "INSERT INTO userInfo (Username, Password1, LastName, FirstName) VALUES ('" + email[i] + "', '" + studentID[i] + "', '" + lastName[i] + "', '" + firstName[i] + "');";

                    int nNoStudentsAdded = DatabaseConnector.CommonFunctions.writeToDatabase(connection, StudentToUserInfoCommand);
                }
                // add to classesTaking table if that combination is not already in the table
                //this will prevent duplicate entries if the roster or individual student is entered
                //twice for the same class

                //make the query string to see if there is a match with the info from the login form
                string checkStudentEnteredQueryText = "select count(*) from classesTaking where Username = '" + email[i] + "' and Course = '" + course_[i] + "';";

                //run the query and get back the number of rows that match the query
                int noRowEnteredStudent = DatabaseConnector.CommonFunctions.noRowsContainingInfo(connection, checkStudentEnteredQueryText);

                //check if the number of rows is <1 if so add student and course to table
                if (noRowEnteredStudent < 1)
                {
                    string StudentClassesTakingCommand = "INSERT INTO classesTaking (Username, Course) VALUES ('" + email[i] + "', '" + course_[i] + "');";

                    int nNoAddedClass = DatabaseConnector.CommonFunctions.writeToDatabase(connection, StudentClassesTakingCommand);
                }

            }
        
        }

        /// <summary>
        ///Delete a student from all classes helper function 
        ///database connection must have already been done
        /// </summary>
        /// <param name="emailDel"></param>
        /// <param name="cmd"></param>
        public void deleteFromAllClassesHelper(string emailDel, OleDbCommand cmd)
        {
            //delete all instances of student from Classes Taking table
            string commandDelClassesTaking = "DELETE FROM ClassesTaking WHERE UserName = '" + emailDel + "'";
            //use the command that was sent in
            cmd.CommandText = commandDelClassesTaking;

            //execute the command
            int nNoDelClassesTaking = cmd.ExecuteNonQuery();

            //also delete from userinfo table
            string commandDelUserInfo = "DELETE FROM userInfo WHERE UserName = '" + emailDel + "'";
            //use the command that was sent in
            cmd.CommandText = commandDelUserInfo;

            //execute the command
            int nNoDelUserInfo = cmd.ExecuteNonQuery();   
        }




        //Delete a student from a class

        /// <summary>
        /// Deletes a student from a class by deleting the row for that student in the ClassesTaking
        /// table.  If the student is in no other classes it will also delete the student from 
        /// the userInfo table.
        /// </summary>
        /// <param name="StudentIDIn"></param>
        /// <param name="ClassIDIn"></param>
        public void deleteStudentFromACourse(string emailDel, string classIDDel)
        {

            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //check if the student is taking more than one class 
            //make the query string to see if there is a match with the info from the login form
            string checkClassesStudentTaking = "select count(*) from classesTaking where Username = '" + emailDel + "';";

            //run the query and get back the number of rows that match the query
            int noClassesStudentTaking = DatabaseConnector.CommonFunctions.noRowsContainingInfo(connection, checkClassesStudentTaking);

            //if results are 0 - no action needs to take place
            //if results are 1 - delete student from classesTaking and UserInfo tables
            //if results are >1 - delete student and course combo only from classesTaking table


            if (noClassesStudentTaking == 1)
            {
                deleteFromAllClassesHelper(emailDel, cmd);
            }
            else if (noClassesStudentTaking > 1)
            {
                //more than one class - so just delete combo from classesTaking Table
                //more than one class so can  dele by username  and course
                string commandDelClassesTaking = "DELETE FROM ClassesTaking WHERE UserName = '" + emailDel + "' and Course = '" + classIDDel + "'";
                //use the command that was sent in
                cmd.CommandText = commandDelClassesTaking;
                //execute the command
                int nNoDelUserInfo = cmd.ExecuteNonQuery();
            }
        }
        public void deleteStudentFromAllCourses(string emailDel)
        {
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //Delete student from all tables
            deleteFromAllClassesHelper(emailDel, cmd);

        }


        /// <summary>
        /// Removes all the student data from 3 tables - used at the end of the 
        /// semester
        /// </summary>
        public void purgeAllStudentData()
        {
             //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            string commandDelAllClassesTaking= "DELETE * FROM ClassesTaking";
            //use the command that was sent in
            cmd.CommandText = commandDelAllClassesTaking;
            //execute the command
            int nNoDelClassesTaking = cmd.ExecuteNonQuery();

            string commandDelAlluserInfo= "DELETE * FROM UserInfo";
            //use the command that was sent in
            cmd.CommandText = commandDelAlluserInfo;
            //execute the command
            int nNoDelUserInfo = cmd.ExecuteNonQuery();

            string commandDelAllCourses= "DELETE * FROM AllCourses";
            //use the command that was sent in
            cmd.CommandText = commandDelAllCourses;
            //execute the command
            int nNoDelAllCourses = cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// this returns a list of the classes the student is taking
        /// so that he can choose which room to be in
        /// </summary>
        /// <param name="emailStudent"></param>
        /// <returns></returns>
        public List<string> getClassesStudentTaking(string emailStudent)
        {
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            //Create the command for the database connection
            OleDbCommand cmd = DatabaseConnector.CommonFunctions.buildDatabaseConnectionCommand(connection);

            //check if the student is taking more than one class 
            //make the query string to see if there is a match with the info from the login form
            string returnClassesStudentTaking = "select from classesTaking where Username = '" + emailStudent + "';";

            //run the query and get back the number of rows that match the query
            List<string> listClassesStudentTaking = DatabaseConnector.CommonFunctions.readData(connection, returnClassesStudentTaking);

            return listClassesStudentTaking;
        }
    }
}

