//CS350 Spring 2014
//CS Connect Group 3
//This program is for opening an Excel Spreadsheet and reading data from it
//It will be used to get student info from the roster spreadsheets and put into 
//the access database 


#define DEBUG

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



namespace MainProgram
{
    class Program
    {
        static void Main()
        {
            //Read required data from Excel Worksheet
            string excelFileName = "C:\\Users\\briggs_mc\\cs350\\CS-connect\\ExcelReader\\CS141roosterTest.xlsx";
            Workbook workbook = ExcelReader.ExcelReader.openWorkbook(excelFileName);
            string[] course;
            string[] studentID;
            string[] lastName;
            string[] firstName;
            string[] email;
            //object[,] valueArray = 
            ExcelReader.ExcelReader.readWorksheet(workbook, out course, out studentID, 
                out lastName, out firstName, out email);
            
            //Post to DataBase
            //call database connection function
            OleDbConnection connection = DatabaseConnector.CommonFunctions.connectToDB();

            // Create a command

            OleDbCommand cmd = new OleDbCommand();

            // Use the connection that was passed in

            cmd.Connection = connection;

            // The command will be a text command.

            cmd.CommandType = CommandType.Text;

            //the write command text
            //write the command text for multiple rows using only needed fields
            //start with array index 2 - array index 0 is not writen from excel and 1 is used for the headers
            // - this command is for inserting the required fields into the database
            //with the course in Class 1 field
            //it does not check if the student already exists in the database
            //If the student already exists the course number should be placed in the first available Class field

            for (int i = 2; i < studentID.Length; ++i)
            {
                string command = "INSERT INTO userInfo (Username, Password1, StudentID, StudentName, Class1) VALUES ('" + email[i] + "', '" + studentID[i] + "', '" + lastName[i] + "', '" + firstName[i] + "', '" + course[i] + "');";
                //string command = "INSERT INTO userInfo (Username, Password1, StudentID, StudentName, Class1) VALUES (" + "jfkldsf"+ ", " + StudentID[2] +", "+ LastName[2]+ ", "+FirstName[2]+ ", "+Course[2]+");";

                int nNoAdded = DatabaseConnector.CommonFunctions.writeToDatabase(connection, command);
            }

        }

        ////Open an Excel  workbook
        //public static Workbook openWorkbook()
        //{

        //    //create the Application object we can use in the member functions.
        //    Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
        //    _excelApp.Visible = true;

        //    string fileName = "C:\\Users\\briggs_mc\\cs350\\CS-connect\\ExcelReader\\CS141roosterTest.xlsx";

        //    //open the workbook
        //    Workbook workbook = _excelApp.Workbooks.Open(fileName,
        //        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing);

        //    return workbook;

        //}


        ////Open the first worksheet and get the information
        ////For now I will try to have as parameters the fields I want to get out of the excel document
        ////public static object[,] 
        //public static void readWorksheet(Workbook workbook, out string[] Course, out string[] IndividualID, out string[] LastName, out string[] FirstName, out string[] Email)
        //{
                
            
        //    //select the first sheet        
        //    Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

        //    //find the used range in worksheet
        //    Range excelRange = worksheet.UsedRange;

        //    //get an object array of all of the cells in the worksheet (their values)
        //    object[,] valueArray = (object[,])excelRange.get_Value(
        //                XlRangeValueDataType.xlRangeValueDefault);

        //    //make an array of all the data in each of the columns
        //    string[] YT = new string[worksheet.UsedRange.Rows.Count];
        //    string[] MatchCourse = new string[worksheet.UsedRange.Rows.Count];
        //    string[] Department = new string[worksheet.UsedRange.Rows.Count];
        //    Course = new string[worksheet.UsedRange.Rows.Count];
        //    string[] Section = new string[worksheet.UsedRange.Rows.Count];
        //    string[] FinalGrade = new string[worksheet.UsedRange.Rows.Count];
        //    IndividualID = new string[worksheet.UsedRange.Rows.Count];
        //    string[] Classification = new string[worksheet.UsedRange.Rows.Count];
        //    string[] EnrollmentStatus = new string[worksheet.UsedRange.Rows.Count];
        //    LastName = new string[worksheet.UsedRange.Rows.Count];
        //    FirstName = new string[worksheet.UsedRange.Rows.Count];
        //    string[] Nickname = new string[worksheet.UsedRange.Rows.Count];
        //    string[] Phone = new string[worksheet.UsedRange.Rows.Count];
        //    Email = new string[worksheet.UsedRange.Rows.Count];
        //    string[] Notes = new string[worksheet.UsedRange.Rows.Count];
                
               
        //    //access the cells 
        //    //go through the rows and put the values from each column into the correct array
        //    for (int row =1; row < worksheet.UsedRange.Rows.Count; ++row)
        //    {
                    
                    
        //        int col = 1;
        //        YT[row] = valueArray[row,col].ToString();
        //        MatchCourse[row] = valueArray[row,++col].ToString();
        //        Department[row] = valueArray[row,++col].ToString();
        //        Course[row] = valueArray[row,++col].ToString();
        //        Section[row] = valueArray[row,++col].ToString();
        //        FinalGrade[row] = valueArray[row, ++col].ToString();
        //        IndividualID[row] = valueArray[row, ++col].ToString();
        //        Classification[row] = valueArray[row, ++col].ToString();
        //        EnrollmentStatus[row] = valueArray[row, ++col].ToString();
        //        LastName[row] = valueArray[row, ++col].ToString();
        //        FirstName[row] = valueArray[row, ++col].ToString();
        //        Nickname[row] = valueArray[row, ++col].ToString();
        //        Phone[row] = valueArray[row, ++col].ToString();
        //        Email[row] = valueArray[row, ++col].ToString();
        //        Notes[row] = valueArray[row, ++col].ToString();


        //    }
            ////clean up stuffs
            //workbook.Close(false, Type.Missing, Type.Missing);
            //Marshal.ReleaseComObject(workbook);

            //return valueArray;



            //_excelApp.Quit();
            //Marshal.FinalReleaseComObject(_excelApp);
        //}
        
    }
}
