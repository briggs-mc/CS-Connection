//CS350 Spring 2014
//CS Connect Group 3
//This class opens an Excel workbook and gets the data from it

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
    class ExcelReader
    {
        
        //Open an Excel  workbook
        public static Workbook openWorkbook(string fileName)
        {

            //create the Application object we can use in the member functions.
            Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
            //if false does not open a window for Excel
            _excelApp.Visible = false;

            

            //open the workbook
            Workbook workbook = _excelApp.Workbooks.Open(fileName,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);

            return workbook;
            

        }

        //Open the first worksheet and get the information
        //I am only outputting certain fields - the other fields maybe private data that will not be
        //entered into the database
        //For now I will try to have as parameters the fields I want to get out of the excel document
        //Maybe they should be public data members or private data members with access functions 

        public static void readWorksheet(Workbook workbook, out string[] course, out string[] individualID, out string[] lastName, out string[] firstName, out string[] email)
        {


            //select the first sheet        
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            //find the used range in worksheet
            Range excelRange = worksheet.UsedRange;

            //get an object array of all of the cells in the worksheet (their values)
            object[,] valueArray = (object[,])excelRange.get_Value(
                        XlRangeValueDataType.xlRangeValueDefault);

            //make an array of all the data in each of the columns
            string[] yT = new string[worksheet.UsedRange.Rows.Count];
            string[] matchCourse = new string[worksheet.UsedRange.Rows.Count];
            string[] department = new string[worksheet.UsedRange.Rows.Count];
            course = new string[worksheet.UsedRange.Rows.Count];
            string[] section = new string[worksheet.UsedRange.Rows.Count];
            string[] finalGrade = new string[worksheet.UsedRange.Rows.Count];
            individualID = new string[worksheet.UsedRange.Rows.Count];
            string[] classification = new string[worksheet.UsedRange.Rows.Count];
            string[] enrollmentStatus = new string[worksheet.UsedRange.Rows.Count];
            lastName = new string[worksheet.UsedRange.Rows.Count];
            firstName = new string[worksheet.UsedRange.Rows.Count];
            string[] nickname = new string[worksheet.UsedRange.Rows.Count];
            string[] phone = new string[worksheet.UsedRange.Rows.Count];
            email = new string[worksheet.UsedRange.Rows.Count];
            string[] notes = new string[worksheet.UsedRange.Rows.Count];


            //access the cells 
            //go through the rows and put the values from each column into the correct array
            for (int row = 1; row < worksheet.UsedRange.Rows.Count; ++row)
            {


                int col = 1;
                yT[row] = valueArray[row, col].ToString();
                matchCourse[row] = valueArray[row, ++col].ToString();
                department[row] = valueArray[row, ++col].ToString();
                course[row] = valueArray[row, ++col].ToString();
                section[row] = valueArray[row, ++col].ToString();
                finalGrade[row] = valueArray[row, ++col].ToString();
                individualID[row] = valueArray[row, ++col].ToString();
                classification[row] = valueArray[row, ++col].ToString();
                enrollmentStatus[row] = valueArray[row, ++col].ToString();
                lastName[row] = valueArray[row, ++col].ToString();
                firstName[row] = valueArray[row, ++col].ToString();
                nickname[row] = valueArray[row, ++col].ToString();
                phone[row] = valueArray[row, ++col].ToString();
                email[row] = valueArray[row, ++col].ToString();
                notes[row] = valueArray[row, ++col].ToString();


            }
            //clean up stuffs
            workbook.Close(false, Type.Missing, Type.Missing);
            Marshal.ReleaseComObject(workbook);

            //I need to figure out how to access _excelApp to quit excel
            //_excelApp.Quit();
            
        }
       // Microsoft.Office.Interop.Excel.Application _excelApp;
    }
}
