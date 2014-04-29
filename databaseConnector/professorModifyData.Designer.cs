namespace ProfessorLoginForm
{
    partial class professorModifyData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.profFilePathTextBox = new System.Windows.Forms.TextBox();
            this.profAddStudentEmailTextBox = new System.Windows.Forms.TextBox();
            this.profRemoveStudentIDTextBox = new System.Windows.Forms.TextBox();
            this.profAddClassIDTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.profRemoveClassIDTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.profAddClassButton = new System.Windows.Forms.Button();
            this.profAddStudentButton = new System.Windows.Forms.Button();
            this.profRemoveStudentFromAllClassesButton = new System.Windows.Forms.Button();
            this.profRemoveStudentButton = new System.Windows.Forms.Button();
            this.profClearAllDataButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.studentIDTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modify database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filename with path:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Student (Enter this)@students.lynchburg.edu:";
            // 
            // profFilePathTextBox
            // 
            this.profFilePathTextBox.Location = new System.Drawing.Point(184, 78);
            this.profFilePathTextBox.Name = "profFilePathTextBox";
            this.profFilePathTextBox.Size = new System.Drawing.Size(223, 20);
            this.profFilePathTextBox.TabIndex = 4;
            this.profFilePathTextBox.TextChanged += new System.EventHandler(this.profFilePathTextBox_TextChanged);
            // 
            // profAddStudentEmailTextBox
            // 
            this.profAddStudentEmailTextBox.Location = new System.Drawing.Point(255, 161);
            this.profAddStudentEmailTextBox.Name = "profAddStudentEmailTextBox";
            this.profAddStudentEmailTextBox.Size = new System.Drawing.Size(152, 20);
            this.profAddStudentEmailTextBox.TabIndex = 5;
            this.profAddStudentEmailTextBox.TextChanged += new System.EventHandler(this.profAddStudentEmailTextBox_TextChanged);
            // 
            // profRemoveStudentIDTextBox
            // 
            this.profRemoveStudentIDTextBox.Location = new System.Drawing.Point(255, 371);
            this.profRemoveStudentIDTextBox.Name = "profRemoveStudentIDTextBox";
            this.profRemoveStudentIDTextBox.Size = new System.Drawing.Size(152, 20);
            this.profRemoveStudentIDTextBox.TabIndex = 6;
            this.profRemoveStudentIDTextBox.TextChanged += new System.EventHandler(this.profRemoveStudentIDTextBox_TextChanged);
            // 
            // profAddClassIDTextBox
            // 
            this.profAddClassIDTextBox.Location = new System.Drawing.Point(255, 197);
            this.profAddClassIDTextBox.Name = "profAddClassIDTextBox";
            this.profAddClassIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.profAddClassIDTextBox.TabIndex = 7;
            this.profAddClassIDTextBox.TextChanged += new System.EventHandler(this.profAddClassIDTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Clear stored data (at end of semester):";
            // 
            // profRemoveClassIDTextBox
            // 
            this.profRemoveClassIDTextBox.Location = new System.Drawing.Point(255, 411);
            this.profRemoveClassIDTextBox.Name = "profRemoveClassIDTextBox";
            this.profRemoveClassIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.profRemoveClassIDTextBox.TabIndex = 10;
            this.profRemoveClassIDTextBox.TextChanged += new System.EventHandler(this.profRemoveClassIDTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(252, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Add a  class";
            // 
            // profAddClassButton
            // 
            this.profAddClassButton.Location = new System.Drawing.Point(442, 81);
            this.profAddClassButton.Name = "profAddClassButton";
            this.profAddClassButton.Size = new System.Drawing.Size(75, 23);
            this.profAddClassButton.TabIndex = 12;
            this.profAddClassButton.Text = "Add Class";
            this.profAddClassButton.UseVisualStyleBackColor = true;
            this.profAddClassButton.Click += new System.EventHandler(this.profAddClassButton_Click);
            // 
            // profAddStudentButton
            // 
            this.profAddStudentButton.Location = new System.Drawing.Point(442, 280);
            this.profAddStudentButton.Name = "profAddStudentButton";
            this.profAddStudentButton.Size = new System.Drawing.Size(75, 23);
            this.profAddStudentButton.TabIndex = 13;
            this.profAddStudentButton.Text = "Add Student";
            this.profAddStudentButton.UseVisualStyleBackColor = true;
            this.profAddStudentButton.Click += new System.EventHandler(this.profAddStudentButton_Click);
            // 
            // profRemoveStudentFromAllClassesButton
            // 
            this.profRemoveStudentFromAllClassesButton.Location = new System.Drawing.Point(442, 409);
            this.profRemoveStudentFromAllClassesButton.Name = "profRemoveStudentFromAllClassesButton";
            this.profRemoveStudentFromAllClassesButton.Size = new System.Drawing.Size(134, 23);
            this.profRemoveStudentFromAllClassesButton.TabIndex = 14;
            this.profRemoveStudentFromAllClassesButton.Text = "Remove from all classes";
            this.profRemoveStudentFromAllClassesButton.UseVisualStyleBackColor = true;
            this.profRemoveStudentFromAllClassesButton.Click += new System.EventHandler(this.profRemoveStudentFromAllClassesButton_Click);
            // 
            // profRemoveStudentButton
            // 
            this.profRemoveStudentButton.Location = new System.Drawing.Point(442, 368);
            this.profRemoveStudentButton.Name = "profRemoveStudentButton";
            this.profRemoveStudentButton.Size = new System.Drawing.Size(98, 23);
            this.profRemoveStudentButton.TabIndex = 15;
            this.profRemoveStudentButton.Text = "Remove student";
            this.profRemoveStudentButton.UseVisualStyleBackColor = true;
            this.profRemoveStudentButton.Click += new System.EventHandler(this.profRemoveStudentButton_Click);
            // 
            // profClearAllDataButton
            // 
            this.profClearAllDataButton.Location = new System.Drawing.Point(442, 459);
            this.profClearAllDataButton.Name = "profClearAllDataButton";
            this.profClearAllDataButton.Size = new System.Drawing.Size(98, 23);
            this.profClearAllDataButton.TabIndex = 16;
            this.profClearAllDataButton.Text = "Clear all data";
            this.profClearAllDataButton.UseVisualStyleBackColor = true;
            this.profClearAllDataButton.Click += new System.EventHandler(this.profClearAllDataButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(252, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Add a student";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(252, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Remove a student";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 374);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Student (Enter this)@students.lynchburg.edu:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 414);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Class (ex CS141): ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Class (ex CS141): ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(176, 236);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 22;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.lastNameTextBox_TextChanged);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(426, 236);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 22;
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.firstNameTextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(311, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "First Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(142, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Student ID: ";
            // 
            // studentIDTextBox
            // 
            this.studentIDTextBox.Location = new System.Drawing.Point(257, 280);
            this.studentIDTextBox.Name = "studentIDTextBox";
            this.studentIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.studentIDTextBox.TabIndex = 24;
            this.studentIDTextBox.TextChanged += new System.EventHandler(this.studentIDTextBox_TextChanged);
            // 
            // professorModifyData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 504);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.studentIDTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.profClearAllDataButton);
            this.Controls.Add(this.profRemoveStudentButton);
            this.Controls.Add(this.profRemoveStudentFromAllClassesButton);
            this.Controls.Add(this.profAddStudentButton);
            this.Controls.Add(this.profAddClassButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.profRemoveClassIDTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.profAddClassIDTextBox);
            this.Controls.Add(this.profRemoveStudentIDTextBox);
            this.Controls.Add(this.profAddStudentEmailTextBox);
            this.Controls.Add(this.profFilePathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "professorModifyData";
            this.Text = "professorModifyData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox profFilePathTextBox;
        private System.Windows.Forms.TextBox profAddStudentEmailTextBox;
        private System.Windows.Forms.TextBox profRemoveStudentIDTextBox;
        private System.Windows.Forms.TextBox profAddClassIDTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox profRemoveClassIDTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button profAddClassButton;
        private System.Windows.Forms.Button profAddStudentButton;
        private System.Windows.Forms.Button profRemoveStudentFromAllClassesButton;
        private System.Windows.Forms.Button profRemoveStudentButton;
        private System.Windows.Forms.Button profClearAllDataButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox studentIDTextBox;
    }
}