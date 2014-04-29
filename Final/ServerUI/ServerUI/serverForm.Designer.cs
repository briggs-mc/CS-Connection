namespace ServerUI
{
    partial class serverForm
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
            this.messageOfTheDayTextBox = new System.Windows.Forms.TextBox();
            this.openServerButton = new System.Windows.Forms.Button();
            this.closeServerButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageOfTheDayLabel = new System.Windows.Forms.Label();
            this.ClientListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageOfTheDayTextBox
            // 
            this.messageOfTheDayTextBox.Location = new System.Drawing.Point(179, 239);
            this.messageOfTheDayTextBox.Name = "messageOfTheDayTextBox";
            this.messageOfTheDayTextBox.Size = new System.Drawing.Size(100, 20);
            this.messageOfTheDayTextBox.TabIndex = 0;
            this.messageOfTheDayTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // openServerButton
            // 
            this.openServerButton.Location = new System.Drawing.Point(115, 275);
            this.openServerButton.Name = "openServerButton";
            this.openServerButton.Size = new System.Drawing.Size(75, 23);
            this.openServerButton.TabIndex = 1;
            this.openServerButton.Text = "Start Server";
            this.openServerButton.UseVisualStyleBackColor = true;
            this.openServerButton.Click += new System.EventHandler(this.openServerButton_Click);
            // 
            // closeServerButton
            // 
            this.closeServerButton.Location = new System.Drawing.Point(258, 275);
            this.closeServerButton.Name = "closeServerButton";
            this.closeServerButton.Size = new System.Drawing.Size(75, 23);
            this.closeServerButton.TabIndex = 3;
            this.closeServerButton.Text = "Close Server";
            this.closeServerButton.UseVisualStyleBackColor = true;
            this.closeServerButton.Click += new System.EventHandler(this.closeServerButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(420, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.viewLogToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.viewLogToolStripMenuItem.Text = "View Log";
            // 
            // messageOfTheDayLabel
            // 
            this.messageOfTheDayLabel.AutoSize = true;
            this.messageOfTheDayLabel.Location = new System.Drawing.Point(28, 242);
            this.messageOfTheDayLabel.Name = "messageOfTheDayLabel";
            this.messageOfTheDayLabel.Size = new System.Drawing.Size(130, 13);
            this.messageOfTheDayLabel.TabIndex = 7;
            this.messageOfTheDayLabel.Text = "Enter message of the day:";
            // 
            // ClientListBox
            // 
            this.ClientListBox.FormattingEnabled = true;
            this.ClientListBox.Location = new System.Drawing.Point(0, 0);
            this.ClientListBox.Name = "ClientListBox";
            this.ClientListBox.Size = new System.Drawing.Size(420, 212);
            this.ClientListBox.TabIndex = 8;
            this.ClientListBox.SelectedIndexChanged += new System.EventHandler(this.ClientListBox_SelectedIndexChanged);
            // 
            // serverForm
            // 
            this.AcceptButton = this.openServerButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 310);
            this.Controls.Add(this.ClientListBox);
            this.Controls.Add(this.messageOfTheDayLabel);
            this.Controls.Add(this.closeServerButton);
            this.Controls.Add(this.openServerButton);
            this.Controls.Add(this.messageOfTheDayTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "serverForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageOfTheDayTextBox;
        private System.Windows.Forms.Button openServerButton;
        private System.Windows.Forms.Button closeServerButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.Label messageOfTheDayLabel;
        private System.Windows.Forms.ListBox ClientListBox;
    }
}

