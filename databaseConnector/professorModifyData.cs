using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProfessorLoginForm
{
    public partial class professorModifyData : Form
    {
        public professorModifyData()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void profFilePathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnFilePath()
        {
            return profFilePathTextBox.Text;
        }

        /// <summary>
        /// When the professor wants to add a class roster to the database
        /// he puts the path and file name for the roster and clicks 
        /// add class this will read the excel file and put the necessary info into
        /// the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profAddClassButton_Click(object sender, EventArgs e)
        {
            string excelFileName = profFilePathTextBox.Text;
            FillDatabase myFillDatabase = new FillDatabase();
            myFillDatabase.getRoster(excelFileName);
            myFillDatabase.rosterToDatabaseTables();
        }

        private void profAddStudentEmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnStudentEmailID()
        {
            return profAddStudentEmailTextBox.Text;
        }

        private void profAddClassIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnAddStudentClass()
        {
            return profAddClassIDTextBox.Text;
        }



        /// <summary>
        /// This will allow a professor to add a single student to a class in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profAddStudentButton_Click(object sender, EventArgs e)
        {
            // Declare and set array element values 

            string[] classIDIn = new string[3];
            string[] studentIDIn = new string[3];
            string[] lastNameIn = new string[3];
            string[] firstNameIn = new string[3];
            string[] emailIn = new string[3];

            //to match the first data field when the data is read from excel, set
            //element 2
            classIDIn[2]   = returnAddStudentClass();
            studentIDIn[2] = returnStudentID();
            lastNameIn[2]  = returnLastName();
            firstNameIn[2] = returnFirstName();
            emailIn[2]     = returnStudentEmailID() + "@students.lynchburg.edu";

            //make an instance of myFillDatabase
            FillDatabase myFillDatabase = new FillDatabase();
            //since we are not using an excel file we have to set the fields
            myFillDatabase.setUserInfo(classIDIn, studentIDIn, lastNameIn, firstNameIn, emailIn);
            //send the info to the database
            myFillDatabase.rosterToDatabaseTables();
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnLastName()
        {
            return lastNameTextBox.Text;
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnFirstName()
        {
            return firstNameTextBox.Text;
        }

        private void studentIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnStudentID()
        {
            return studentIDTextBox.Text;
        }

        private void profRemoveStudentFromAllClassesButton_Click(object sender, EventArgs e)
        {
            //this will remove a student from all classes
            //make an instance of myFillDatabase
            FillDatabase myFillDatabase = new FillDatabase();
            
            myFillDatabase.deleteStudentFromAllCourses(returnRemoveStudentID());
  
        }

        private void profRemoveStudentButton_Click(object sender, EventArgs e)
        {
            //this will remove a student from a single class
            //make an instance of myFillDatabase
            FillDatabase myFillDatabase = new FillDatabase();

            myFillDatabase.deleteStudentFromACourse(returnRemoveStudentID(), returnRemoveClassID());
        }

            private void profRemoveStudentIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnRemoveStudentID()
        {
            return profRemoveStudentIDTextBox.Text + "@students.lynchburg.edu"; ;
        }

        private void profRemoveClassIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public string returnRemoveClassID()
        {
            return profRemoveClassIDTextBox.Text;
        }

        private void profClearAllDataButton_Click(object sender, EventArgs e)
        {
            //clear the userInfo, classesTaking, and allCourses tables
            //this should only be done at the end of the semester
            
            FillDatabase myFillDatabase = new FillDatabase();

            myFillDatabase.purgeAllStudentData();

        }

    }
}
