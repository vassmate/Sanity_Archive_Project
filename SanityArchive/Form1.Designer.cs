namespace SanityArchive
{
    partial class SanityArchiveForm
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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.contentListBox = new System.Windows.Forms.ListBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.compressButton = new System.Windows.Forms.Button();
            this.fileHandlingLabel = new System.Windows.Forms.Label();
            this.fileModifyingStructurallyLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.propertiesButton = new System.Windows.Forms.Button();
            this.driveLabel = new System.Windows.Forms.Label();
            this.drivesBox = new System.Windows.Forms.ComboBox();
            this.sizeUnitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(64, 47);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(312, 20);
            this.pathTextBox.TabIndex = 2;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(25, 50);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(32, 13);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "Path:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(391, 45);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(60, 23);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(721, 20);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(63, 23);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(552, 26);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(30, 13);
            this.sizeLabel.TabIndex = 7;
            this.sizeLabel.Text = "Size:";
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(588, 23);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.ReadOnly = true;
            this.sizeTextBox.Size = new System.Drawing.Size(68, 20);
            this.sizeTextBox.TabIndex = 8;
            // 
            // contentListBox
            // 
            this.contentListBox.FormattingEnabled = true;
            this.contentListBox.Location = new System.Drawing.Point(28, 87);
            this.contentListBox.Name = "contentListBox";
            this.contentListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.contentListBox.Size = new System.Drawing.Size(776, 199);
            this.contentListBox.TabIndex = 9;
            this.contentListBox.SelectedIndexChanged += new System.EventHandler(this.contentListBox_SelectedIndexChanged);
            this.contentListBox.DoubleClick += new System.EventHandler(this.contentListBox_DoubleClick);
       //     this.contentListBox.LostFocus+= new System.EventHandler(this.contentListBox_LostFocus);
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.SystemColors.Control;
            this.copyButton.Location = new System.Drawing.Point(28, 352);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 10;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = false;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(130, 352);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 11;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(231, 352);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Enabled = false;
            this.encryptButton.Location = new System.Drawing.Point(515, 352);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 13;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // compressButton
            // 
            this.compressButton.Enabled = false;
            this.compressButton.Location = new System.Drawing.Point(616, 352);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(75, 23);
            this.compressButton.TabIndex = 14;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // fileHandlingLabel
            // 
            this.fileHandlingLabel.AutoSize = true;
            this.fileHandlingLabel.Location = new System.Drawing.Point(25, 319);
            this.fileHandlingLabel.Name = "fileHandlingLabel";
            this.fileHandlingLabel.Size = new System.Drawing.Size(69, 13);
            this.fileHandlingLabel.TabIndex = 15;
            this.fileHandlingLabel.Text = "File handling:";
            // 
            // fileModifyingStructurallyLabel
            // 
            this.fileModifyingStructurallyLabel.AutoSize = true;
            this.fileModifyingStructurallyLabel.Location = new System.Drawing.Point(512, 319);
            this.fileModifyingStructurallyLabel.Name = "fileModifyingStructurallyLabel";
            this.fileModifyingStructurallyLabel.Size = new System.Drawing.Size(126, 13);
            this.fileModifyingStructurallyLabel.TabIndex = 16;
            this.fileModifyingStructurallyLabel.Text = "File modifying structurally:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(331, 352);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // propertiesButton
            // 
            this.propertiesButton.Enabled = false;
            this.propertiesButton.Location = new System.Drawing.Point(721, 351);
            this.propertiesButton.Name = "propertiesButton";
            this.propertiesButton.Size = new System.Drawing.Size(75, 23);
            this.propertiesButton.TabIndex = 18;
            this.propertiesButton.Text = "Properties";
            this.propertiesButton.UseVisualStyleBackColor = true;
            this.propertiesButton.Click += new System.EventHandler(this.propertiesButton_Click);
            // 
            // driveLabel
            // 
            this.driveLabel.AutoSize = true;
            this.driveLabel.Location = new System.Drawing.Point(25, 21);
            this.driveLabel.Name = "driveLabel";
            this.driveLabel.Size = new System.Drawing.Size(35, 13);
            this.driveLabel.TabIndex = 19;
            this.driveLabel.Text = "Drive:";
            // 
            // drivesBox
            // 
            this.drivesBox.FormattingEnabled = true;
            this.drivesBox.Location = new System.Drawing.Point(64, 18);
            this.drivesBox.Name = "drivesBox";
            this.drivesBox.Size = new System.Drawing.Size(312, 21);
            this.drivesBox.TabIndex = 20;
            this.drivesBox.SelectedIndexChanged += new System.EventHandler(this.drivesBox_SelectedIndexChanged);
            // 
            // sizeUnitLabel
            // 
            this.sizeUnitLabel.AutoSize = true;
            this.sizeUnitLabel.Location = new System.Drawing.Point(660, 26);
            this.sizeUnitLabel.Name = "sizeUnitLabel";
            this.sizeUnitLabel.Size = new System.Drawing.Size(27, 13);
            this.sizeUnitLabel.TabIndex = 21;
            this.sizeUnitLabel.Text = "byte";
            // 
            // SanityArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 399);
            this.Controls.Add(this.sizeUnitLabel);
            this.Controls.Add(this.drivesBox);
            this.Controls.Add(this.driveLabel);
            this.Controls.Add(this.propertiesButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.fileModifyingStructurallyLabel);
            this.Controls.Add(this.fileHandlingLabel);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.contentListBox);
            this.Controls.Add(this.sizeTextBox);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathTextBox);
            this.MaximumSize = new System.Drawing.Size(856, 438);
            this.MinimumSize = new System.Drawing.Size(856, 438);
            this.Name = "SanityArchiveForm";
            this.Text = "Sanity Archive";
            this.Load += new System.EventHandler(this.SanityArchiveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.ListBox contentListBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Label fileHandlingLabel;
        private System.Windows.Forms.Label fileModifyingStructurallyLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button propertiesButton;
        private System.Windows.Forms.Label driveLabel;
        private System.Windows.Forms.ComboBox drivesBox;
		private System.Windows.Forms.Label sizeUnitLabel;
	}
}

