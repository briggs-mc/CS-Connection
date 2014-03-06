namespace UserInterface
{
    partial class registerForm
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
            this.registrationTopLabel = new System.Windows.Forms.Label();
            this.confirmUserLabel = new System.Windows.Forms.Label();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.confirmUsernameTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.emailSubscriptRegisterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registrationTopLabel
            // 
            this.registrationTopLabel.AutoSize = true;
            this.registrationTopLabel.Location = new System.Drawing.Point(108, 9);
            this.registrationTopLabel.Name = "registrationTopLabel";
            this.registrationTopLabel.Size = new System.Drawing.Size(63, 13);
            this.registrationTopLabel.TabIndex = 0;
            this.registrationTopLabel.Text = "Registration";
            // 
            // confirmUserLabel
            // 
            this.confirmUserLabel.AutoSize = true;
            this.confirmUserLabel.Location = new System.Drawing.Point(12, 36);
            this.confirmUserLabel.Name = "confirmUserLabel";
            this.confirmUserLabel.Size = new System.Drawing.Size(58, 13);
            this.confirmUserLabel.TabIndex = 1;
            this.confirmUserLabel.Text = "Username:";
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(12, 96);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(81, 13);
            this.newPasswordLabel.TabIndex = 2;
            this.newPasswordLabel.Text = "New Password:";
            // 
            // confirmUsernameTextBox
            // 
            this.confirmUsernameTextBox.Location = new System.Drawing.Point(128, 33);
            this.confirmUsernameTextBox.Name = "confirmUsernameTextBox";
            this.confirmUsernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.confirmUsernameTextBox.TabIndex = 3;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(128, 93);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.newPasswordTextBox.TabIndex = 4;
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(128, 147);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.confirmPasswordTextBox.TabIndex = 5;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(12, 154);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(94, 13);
            this.confirmPasswordLabel.TabIndex = 6;
            this.confirmPasswordLabel.Text = "Confirm Password:";
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(141, 203);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 7;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // emailSubscriptRegisterLabel
            // 
            this.emailSubscriptRegisterLabel.AutoSize = true;
            this.emailSubscriptRegisterLabel.Location = new System.Drawing.Point(234, 36);
            this.emailSubscriptRegisterLabel.Name = "emailSubscriptRegisterLabel";
            this.emailSubscriptRegisterLabel.Size = new System.Drawing.Size(128, 13);
            this.emailSubscriptRegisterLabel.TabIndex = 8;
            this.emailSubscriptRegisterLabel.Text = "@students.lynchburg.edu";
            // 
            // registerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 287);
            this.Controls.Add(this.emailSubscriptRegisterLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.confirmUsernameTextBox);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.confirmUserLabel);
            this.Controls.Add(this.registrationTopLabel);
            this.Name = "registerForm";
            this.Text = "registerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label registrationTopLabel;
        private System.Windows.Forms.Label confirmUserLabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox confirmUsernameTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label emailSubscriptRegisterLabel;
    }
}