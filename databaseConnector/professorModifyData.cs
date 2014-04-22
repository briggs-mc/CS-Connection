using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
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

        private void profAddClassButton_Click(object sender, EventArgs e)
        {

        }

        private void profAddStudentIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnAddStudentID()
        {
            return profAddStudentIDTextBox.Text;
        }

        private void profAddClassIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnAddStudentClass()
        {
            return profAddClassIDTextBox.Text;
        }




        private void profRemoveStudentIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnRemoveStudentID()
        {
            return profRemoveStudentIDTextBox.Text;
        }

        private void profRemoveClassIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string returnRemoveStudentID()
        {
            return profRemoveClassIDTextBox.Text;
        }


    }
}
