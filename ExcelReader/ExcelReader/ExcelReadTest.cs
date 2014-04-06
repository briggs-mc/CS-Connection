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

            Workbook workbook = ExcelReader.Program.openWorkbook();
            object[,] valueArray = ExcelReader.Program.readWorksheet(workbook);
            //Assert.AreEqual(valueArray[3, 3].ToString(), "CS");
            Assert.NotNull(valueArray[3, 3]);


        }
    }
}
