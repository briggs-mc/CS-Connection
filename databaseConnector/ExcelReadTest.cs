//tests for the excel reader program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace ExcelReader
{
    [TestFixture]
    public class ExcelReadTest
    {
        //[Test]
        //would like to have a test to just open a workbook, but I cannot find a workbook
        // open status 
        //Test if we can open excel file
        //public static void openWorkbookTest()
        //{

        //    Workbook workbook = ExcelReader.Program.openWorkbook();
        //    Assert. ;
        //}

        [Test]
        //read from worksheet
        public static void readWorksheetTest()
        {
            string excelFileName = "C:\\Users\\briggs_mc\\cs350\\CS-connect\\ExcelReader\\CS141roosterTest.xlsx";
            Workbook workbook = ExcelReader.openWorkbook(excelFileName);
            string[] Course;
            string[] StudentID; 
            string[] LastName ;
            string[] FirstName;
            string[] Email;
            //object[,] valueArray = 
            ExcelReader.readWorksheet(workbook, out Course, out StudentID, out LastName, out FirstName, out Email);

            Assert.IsNotEmpty(Course[1]);
            //Assert.AreEqual(valueArray[3, 3].ToString(), "CS");
            //Assert.NotNull(valueArray[3, 3]);


        }
    }
}
