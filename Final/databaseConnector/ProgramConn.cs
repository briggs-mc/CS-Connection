//CS350 Spring 2014
//CS Connect Group 3  Marisa Briggs, Adam Piersa, Eric Johnson
//This program is for opening an Excel Spreadsheet and reading data from it
//It will be used to get student info from the roster spreadsheets and put into 
//the access database 


#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Net;

using System.ComponentModel;

using System.Drawing;

using System.Windows.Forms;
using System.Threading;



namespace CSConnector
{
    class Program
    {
        static void Main()
        {
           
            //start the professor login screen - this is only temporary - this screen should 
            //be called from the main login screen
            Application.Run(new ProfessorLogin() );

            //provide excel file name - will later be provided through the professor 
            //through an interface
            //string excelFileName = "C:\\Users\\briggs_mc\\cs350\\CS-connect\\DatabaseConnector\\CS142roosterTest.xlsx";
            //FillDatabase myFillDatabase = new FillDatabase();
            //myFillDatabase.getRoster(excelFileName);
            //myFillDatabase.rosterToDatabaseTables();

        }
        
    }
}

