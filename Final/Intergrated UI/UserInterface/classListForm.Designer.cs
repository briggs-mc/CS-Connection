namespace UserInterface
{
    partial class classListForm
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
            this.classListLabel = new System.Windows.Forms.Label();
            this.enterClassesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // classListLabel
            // 
            this.classListLabel.AutoSize = true;
            this.classListLabel.Location = new System.Drawing.Point(142, 18);
            this.classListLabel.Name = "classListLabel";
            this.classListLabel.Size = new System.Drawing.Size(89, 13);
            this.classListLabel.TabIndex = 0;
            this.classListLabel.Text = "Available Classes";
            // 
            // enterClassesButton
            // 
            this.enterClassesButton.Location = new System.Drawing.Point(145, 253);
            this.enterClassesButton.Name = "enterClassesButton";
            this.enterClassesButton.Size = new System.Drawing.Size(75, 23);
            this.enterClassesButton.TabIndex = 1;
            this.enterClassesButton.Text = "Enter";
            this.enterClassesButton.UseVisualStyleBackColor = true;
            this.enterClassesButton.Click += new System.EventHandler(this.enterClassesButton_Click);
            // 
            // classListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 302);
            this.Controls.Add(this.enterClassesButton);
            this.Controls.Add(this.classListLabel);
            this.Name = "classListForm";
            this.Text = "classListForm";
            this.Load += new System.EventHandler(this.classListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label classListLabel;
        private System.Windows.Forms.Button enterClassesButton;

    }
}