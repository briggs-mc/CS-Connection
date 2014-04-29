namespace CSConnector
{
    partial class ProfessorLogin
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
            this.profUsernametextBox = new System.Windows.Forms.TextBox();
            this.profPasswordtextBox = new System.Windows.Forms.TextBox();
            this.profUsernameLabel = new System.Windows.Forms.Label();
            this.profPasswordLabel = new System.Windows.Forms.Label();
            this.profLoginButton = new System.Windows.Forms.Button();
            this.profEmailLabel = new System.Windows.Forms.Label();
            this.professorIntroLabel = new System.Windows.Forms.Label();
            this.profErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // profUsernametextBox
            // 
            this.profUsernametextBox.Location = new System.Drawing.Point(94, 60);
            this.profUsernametextBox.Name = "profUsernametextBox";
            this.profUsernametextBox.Size = new System.Drawing.Size(100, 20);
            this.profUsernametextBox.TabIndex = 0;
            this.profUsernametextBox.TextChanged += new System.EventHandler(this.profUsernametextBox_TextChanged);
            // 
            // profPasswordtextBox
            // 
            this.profPasswordtextBox.Location = new System.Drawing.Point(94, 133);
            this.profPasswordtextBox.Name = "profPasswordtextBox";
            this.profPasswordtextBox.Size = new System.Drawing.Size(100, 20);
            this.profPasswordtextBox.TabIndex = 1;
            this.profPasswordtextBox.TextChanged += new System.EventHandler(this.profPasswordtextBox_TextChanged);
            // 
            // profUsernameLabel
            // 
            this.profUsernameLabel.AutoSize = true;
            this.profUsernameLabel.Location = new System.Drawing.Point(10, 63);
            this.profUsernameLabel.Name = "profUsernameLabel";
            this.profUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.profUsernameLabel.TabIndex = 2;
            this.profUsernameLabel.Text = "Username:";
            // 
            // profPasswordLabel
            // 
            this.profPasswordLabel.AutoSize = true;
            this.profPasswordLabel.Location = new System.Drawing.Point(12, 140);
            this.profPasswordLabel.Name = "profPasswordLabel";
            this.profPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.profPasswordLabel.TabIndex = 3;
            this.profPasswordLabel.Text = "Password:";
            // 
            // profLoginButton
            // 
            this.profLoginButton.Location = new System.Drawing.Point(105, 200);
            this.profLoginButton.Name = "profLoginButton";
            this.profLoginButton.Size = new System.Drawing.Size(75, 23);
            this.profLoginButton.TabIndex = 4;
            this.profLoginButton.Text = "Login";
            this.profLoginButton.UseVisualStyleBackColor = true;
            this.profLoginButton.Click += new System.EventHandler(this.profLoginButton_Click);
            // 
            // profEmailLabel
            // 
            this.profEmailLabel.AutoSize = true;
            this.profEmailLabel.Location = new System.Drawing.Point(200, 63);
            this.profEmailLabel.Name = "profEmailLabel";
            this.profEmailLabel.Size = new System.Drawing.Size(85, 13);
            this.profEmailLabel.TabIndex = 5;
            this.profEmailLabel.Text = "@lynchburg.edu";
            // 
            // professorIntroLabel
            // 
            this.professorIntroLabel.AutoSize = true;
            this.professorIntroLabel.Location = new System.Drawing.Point(91, 19);
            this.professorIntroLabel.Name = "professorIntroLabel";
            this.professorIntroLabel.Size = new System.Drawing.Size(103, 13);
            this.professorIntroLabel.TabIndex = 6;
            this.professorIntroLabel.Text = "Professor login page";
            // 
            // profErrorMessage
            // 
            this.profErrorMessage.AutoSize = true;
            this.profErrorMessage.ForeColor = System.Drawing.Color.DarkRed;
            this.profErrorMessage.Location = new System.Drawing.Point(33, 171);
            this.profErrorMessage.Name = "profErrorMessage";
            this.profErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.profErrorMessage.TabIndex = 7;
            // 
            // ProfessorLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.profErrorMessage);
            this.Controls.Add(this.professorIntroLabel);
            this.Controls.Add(this.profEmailLabel);
            this.Controls.Add(this.profLoginButton);
            this.Controls.Add(this.profPasswordLabel);
            this.Controls.Add(this.profUsernameLabel);
            this.Controls.Add(this.profPasswordtextBox);
            this.Controls.Add(this.profUsernametextBox);
            this.Name = "ProfessorLogin";
            this.Text = "Professor Login";
            this.Load += new System.EventHandler(this.ProfessorLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox profUsernametextBox;
        private System.Windows.Forms.TextBox profPasswordtextBox;
        private System.Windows.Forms.Label profUsernameLabel;
        private System.Windows.Forms.Label profPasswordLabel;
        private System.Windows.Forms.Button profLoginButton;
        private System.Windows.Forms.Label profEmailLabel;
        private System.Windows.Forms.Label professorIntroLabel;
        private System.Windows.Forms.Label profErrorMessage;
    }
}