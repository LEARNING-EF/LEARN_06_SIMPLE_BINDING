namespace LEARNING_EF_CODE_FIRST
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;

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
			this.generateTestDataButton = new System.Windows.Forms.Button();
			this.displayDataButton = new System.Windows.Forms.Button();
			this.usersListBox = new System.Windows.Forms.ListBox();
			this.fullNameTextBox = new System.Windows.Forms.TextBox();
			this.fullNameLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// generateTestDataButton
			// 
			this.generateTestDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.generateTestDataButton.Location = new System.Drawing.Point(12, 12);
			this.generateTestDataButton.Name = "generateTestDataButton";
			this.generateTestDataButton.Size = new System.Drawing.Size(360, 23);
			this.generateTestDataButton.TabIndex = 0;
			this.generateTestDataButton.Text = "Generate Test Data";
			this.generateTestDataButton.UseVisualStyleBackColor = true;
			this.generateTestDataButton.Click += new System.EventHandler(this.GenerateTestDataButton_Click);
			// 
			// displayDataButton
			// 
			this.displayDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.displayDataButton.Location = new System.Drawing.Point(12, 73);
			this.displayDataButton.Name = "displayDataButton";
			this.displayDataButton.Size = new System.Drawing.Size(360, 23);
			this.displayDataButton.TabIndex = 1;
			this.displayDataButton.Text = "Display Data";
			this.displayDataButton.UseVisualStyleBackColor = true;
			this.displayDataButton.Click += new System.EventHandler(this.DisplayDataButton_Click);
			// 
			// usersListBox
			// 
			this.usersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.usersListBox.FormattingEnabled = true;
			this.usersListBox.ItemHeight = 16;
			this.usersListBox.Location = new System.Drawing.Point(12, 102);
			this.usersListBox.Name = "usersListBox";
			this.usersListBox.Size = new System.Drawing.Size(360, 148);
			this.usersListBox.TabIndex = 2;
			this.usersListBox.DoubleClick += new System.EventHandler(this.UsersListBox_DoubleClick);
			// 
			// fullNameTextBox
			// 
			this.fullNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fullNameTextBox.Location = new System.Drawing.Point(98, 41);
			this.fullNameTextBox.Name = "fullNameTextBox";
			this.fullNameTextBox.Size = new System.Drawing.Size(274, 23);
			this.fullNameTextBox.TabIndex = 3;
			// 
			// fullNameLabel
			// 
			this.fullNameLabel.AutoSize = true;
			this.fullNameLabel.Location = new System.Drawing.Point(12, 44);
			this.fullNameLabel.Name = "fullNameLabel";
			this.fullNameLabel.Size = new System.Drawing.Size(80, 16);
			this.fullNameLabel.TabIndex = 4;
			this.fullNameLabel.Text = "&Full Name";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.fullNameLabel);
			this.Controls.Add(this.fullNameTextBox);
			this.Controls.Add(this.usersListBox);
			this.Controls.Add(this.displayDataButton);
			this.Controls.Add(this.generateTestDataButton);
			this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button generateTestDataButton;
		private System.Windows.Forms.Button displayDataButton;
		private System.Windows.Forms.ListBox usersListBox;
		private System.Windows.Forms.TextBox fullNameTextBox;
		private System.Windows.Forms.Label fullNameLabel;
	}
}
