namespace UserInterface
{
    partial class splashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(splashScreen));
            this.signInButton = new System.Windows.Forms.Button();
            this.newUserButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.csWebsiteLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(55, 173);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(75, 23);
            this.signInButton.TabIndex = 0;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // newUserButton
            // 
            this.newUserButton.Location = new System.Drawing.Point(288, 173);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(75, 23);
            this.newUserButton.TabIndex = 1;
            this.newUserButton.Text = "New User?";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(167, 18);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(138, 13);
            this.welcomeLabel.TabIndex = 2;
            this.welcomeLabel.Text = "Welcome to CS Connection";
            // 
            // csWebsiteLabel
            // 
            this.csWebsiteLabel.AutoSize = true;
            this.csWebsiteLabel.Location = new System.Drawing.Point(167, 69);
            this.csWebsiteLabel.Name = "csWebsiteLabel";
            this.csWebsiteLabel.Size = new System.Drawing.Size(124, 13);
            this.csWebsiteLabel.TabIndex = 3;
            this.csWebsiteLabel.TabStop = true;
            this.csWebsiteLabel.Text = "http://cs.lynchburg.edu/";
            this.csWebsiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.csWebsiteLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.csWebsiteLabel_MouseDoubleClick);
            // 
            // splashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(450, 228);
            this.Controls.Add(this.csWebsiteLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.newUserButton);
            this.Controls.Add(this.signInButton);
            this.Name = "splashScreen";
            this.Text = "splashScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.LinkLabel csWebsiteLabel;
    }
}