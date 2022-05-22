namespace ResidentDataConvertApp
{
    partial class DataConvertForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.targetFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.desFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.targetFileButton = new System.Windows.Forms.Button();
            this.destinationButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.SelectFiletextBox = new System.Windows.Forms.TextBox();
            this.DestinationTextBox = new System.Windows.Forms.TextBox();
            this.progressWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // targetFileDialog
            // 
            this.targetFileDialog.FileName = "targetFileDialog";
            // 
            // targetFileButton
            // 
            this.targetFileButton.Location = new System.Drawing.Point(20, 83);
            this.targetFileButton.Name = "targetFileButton";
            this.targetFileButton.Size = new System.Drawing.Size(75, 24);
            this.targetFileButton.TabIndex = 0;
            this.targetFileButton.Text = "Select File";
            this.targetFileButton.UseVisualStyleBackColor = true;
            this.targetFileButton.Click += new System.EventHandler(this.targetFileButton_Click);
            // 
            // destinationButton
            // 
            this.destinationButton.Location = new System.Drawing.Point(20, 141);
            this.destinationButton.Name = "destinationButton";
            this.destinationButton.Size = new System.Drawing.Size(75, 23);
            this.destinationButton.TabIndex = 1;
            this.destinationButton.Text = "Export to";
            this.destinationButton.UseVisualStyleBackColor = true;
            this.destinationButton.Click += new System.EventHandler(this.destinationButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(96, 228);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(87, 28);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // SelectFiletextBox
            // 
            this.SelectFiletextBox.Location = new System.Drawing.Point(123, 84);
            this.SelectFiletextBox.Name = "SelectFiletextBox";
            this.SelectFiletextBox.ReadOnly = true;
            this.SelectFiletextBox.Size = new System.Drawing.Size(149, 23);
            this.SelectFiletextBox.TabIndex = 3;
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Location = new System.Drawing.Point(123, 141);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.ReadOnly = true;
            this.DestinationTextBox.Size = new System.Drawing.Size(149, 23);
            this.DestinationTextBox.TabIndex = 4;
            // 
            // progressWorker
            // 
            this.progressWorker.WorkerReportsProgress = true;
            this.progressWorker.WorkerSupportsCancellation = true;
            this.progressWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.progressWorker_DoWork);
            this.progressWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.progressWorker_ProgressChanged);
            this.progressWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.progressWorker_RunWorkerCompleted);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProgressLabel.Location = new System.Drawing.Point(110, 183);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(0, 32);
            this.ProgressLabel.TabIndex = 5;
            this.ProgressLabel.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 233);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Convert";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(244, 298);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(37, 15);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "v1.0.0";
            // 
            // DataConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(303, 322);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.DestinationTextBox);
            this.Controls.Add(this.SelectFiletextBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.destinationButton);
            this.Controls.Add(this.targetFileButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataConvertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataConvert";
            this.Load += new System.EventHandler(this.DataConvertForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog targetFileDialog;
        private FolderBrowserDialog desFolderBrowserDialog;
        private Button targetFileButton;
        private Button destinationButton;
        private Button convertButton;
        private TextBox SelectFiletextBox;
        private TextBox DestinationTextBox;
        private System.ComponentModel.BackgroundWorker progressWorker;
        private Label ProgressLabel;
        private GroupBox groupBox1;
        private Label versionLabel;
    }
}