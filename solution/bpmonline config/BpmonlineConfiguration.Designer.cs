namespace BpmOnlineConfig
{
    partial class BpmonlineConfiguration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.edtSessionTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.edtWebSocketsPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtMaxEntityNameLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbUncompressedJS = new System.Windows.Forms.CheckBox();
            this.edtJSPath = new System.Windows.Forms.TextBox();
            this.btnBrowseJSPath = new System.Windows.Forms.Button();
            this.lbJSPath = new System.Windows.Forms.Label();
            this.chbExtractJS = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseCSPath = new System.Windows.Forms.Button();
            this.lbCSPath = new System.Windows.Forms.Label();
            this.chbExtractCS = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbExtractAllCSSources = new System.Windows.Forms.CheckBox();
            this.edtCSPath = new System.Windows.Forms.TextBox();
            this.lbSavingStatus = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.edtApplicatinName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbSchedulerDb = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowseLogPath = new System.Windows.Forms.Button();
            this.edtLogPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBrowseSourceControlAuthPath = new System.Windows.Forms.Button();
            this.edtSourceControlAuthPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBrowseDefWorkingCopyPath = new System.Windows.Forms.Button();
            this.edtDefWorkingCopyPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chbUseSvn = new System.Windows.Forms.CheckBox();
            this.btnBrowseDefPackagesWorkingCopyPath = new System.Windows.Forms.Button();
            this.edtDefPackagesWorkingCopyPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.edtSessionTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxEntityNameLength)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // edtSessionTimeOut
            // 
            this.edtSessionTimeOut.Location = new System.Drawing.Point(181, 16);
            this.edtSessionTimeOut.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.edtSessionTimeOut.Name = "edtSessionTimeOut";
            this.edtSessionTimeOut.Size = new System.Drawing.Size(72, 20);
            this.edtSessionTimeOut.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Session Timeout (minutes)";
            // 
            // edtWebSocketsPort
            // 
            this.edtWebSocketsPort.BackColor = System.Drawing.SystemColors.Window;
            this.edtWebSocketsPort.Location = new System.Drawing.Point(181, 42);
            this.edtWebSocketsPort.MaxLength = 4;
            this.edtWebSocketsPort.Name = "edtWebSocketsPort";
            this.edtWebSocketsPort.Size = new System.Drawing.Size(72, 20);
            this.edtWebSocketsPort.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "WebSockets Port";
            // 
            // edtMaxEntityNameLength
            // 
            this.edtMaxEntityNameLength.BackColor = System.Drawing.SystemColors.Window;
            this.edtMaxEntityNameLength.Location = new System.Drawing.Point(181, 68);
            this.edtMaxEntityNameLength.Name = "edtMaxEntityNameLength";
            this.edtMaxEntityNameLength.Size = new System.Drawing.Size(72, 20);
            this.edtMaxEntityNameLength.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max Entity Name Length";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbUncompressedJS);
            this.groupBox1.Controls.Add(this.edtJSPath);
            this.groupBox1.Controls.Add(this.btnBrowseJSPath);
            this.groupBox1.Controls.Add(this.lbJSPath);
            this.groupBox1.Controls.Add(this.chbExtractJS);
            this.groupBox1.Location = new System.Drawing.Point(17, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 89);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Javascript sources";
            // 
            // chbUncompressedJS
            // 
            this.chbUncompressedJS.AutoSize = true;
            this.chbUncompressedJS.Location = new System.Drawing.Point(127, 28);
            this.chbUncompressedJS.Name = "chbUncompressedJS";
            this.chbUncompressedJS.Size = new System.Drawing.Size(137, 17);
            this.chbUncompressedJS.TabIndex = 4;
            this.chbUncompressedJS.Text = "Uncompressed JS Core";
            this.chbUncompressedJS.UseVisualStyleBackColor = true;
            // 
            // edtJSPath
            // 
            this.edtJSPath.Location = new System.Drawing.Point(51, 51);
            this.edtJSPath.Name = "edtJSPath";
            this.edtJSPath.Size = new System.Drawing.Size(540, 20);
            this.edtJSPath.TabIndex = 2;
            // 
            // btnBrowseJSPath
            // 
            this.btnBrowseJSPath.Location = new System.Drawing.Point(597, 49);
            this.btnBrowseJSPath.Name = "btnBrowseJSPath";
            this.btnBrowseJSPath.Size = new System.Drawing.Size(28, 24);
            this.btnBrowseJSPath.TabIndex = 3;
            this.btnBrowseJSPath.Text = "...";
            this.btnBrowseJSPath.UseVisualStyleBackColor = true;
            this.btnBrowseJSPath.Click += new System.EventHandler(this.btnBrowseJSPath_Click);
            // 
            // lbJSPath
            // 
            this.lbJSPath.AutoSize = true;
            this.lbJSPath.Location = new System.Drawing.Point(7, 55);
            this.lbJSPath.Name = "lbJSPath";
            this.lbJSPath.Size = new System.Drawing.Size(29, 13);
            this.lbJSPath.TabIndex = 1;
            this.lbJSPath.Text = "Path";
            // 
            // chbExtractJS
            // 
            this.chbExtractJS.AutoSize = true;
            this.chbExtractJS.Location = new System.Drawing.Point(10, 28);
            this.chbExtractJS.Name = "chbExtractJS";
            this.chbExtractJS.Size = new System.Drawing.Size(104, 17);
            this.chbExtractJS.TabIndex = 0;
            this.chbExtractJS.Text = "Use File Content";
            this.chbExtractJS.UseVisualStyleBackColor = true;
            this.chbExtractJS.Click += new System.EventHandler(this.chbExtractJS_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\Intel";
            // 
            // btnBrowseCSPath
            // 
            this.btnBrowseCSPath.Location = new System.Drawing.Point(597, 48);
            this.btnBrowseCSPath.Name = "btnBrowseCSPath";
            this.btnBrowseCSPath.Size = new System.Drawing.Size(28, 24);
            this.btnBrowseCSPath.TabIndex = 3;
            this.btnBrowseCSPath.Text = "...";
            this.btnBrowseCSPath.UseVisualStyleBackColor = true;
            this.btnBrowseCSPath.Click += new System.EventHandler(this.btnBrowseCSPath_Click);
            // 
            // lbCSPath
            // 
            this.lbCSPath.AutoSize = true;
            this.lbCSPath.Location = new System.Drawing.Point(7, 51);
            this.lbCSPath.Name = "lbCSPath";
            this.lbCSPath.Size = new System.Drawing.Size(29, 13);
            this.lbCSPath.TabIndex = 1;
            this.lbCSPath.Text = "Path";
            // 
            // chbExtractCS
            // 
            this.chbExtractCS.AutoSize = true;
            this.chbExtractCS.Location = new System.Drawing.Point(10, 25);
            this.chbExtractCS.Name = "chbExtractCS";
            this.chbExtractCS.Size = new System.Drawing.Size(59, 17);
            this.chbExtractCS.TabIndex = 0;
            this.chbExtractCS.Text = "Extract";
            this.chbExtractCS.UseVisualStyleBackColor = true;
            this.chbExtractCS.Click += new System.EventHandler(this.chbExtractCS_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbExtractAllCSSources);
            this.groupBox2.Controls.Add(this.btnBrowseCSPath);
            this.groupBox2.Controls.Add(this.edtCSPath);
            this.groupBox2.Controls.Add(this.lbCSPath);
            this.groupBox2.Controls.Add(this.chbExtractCS);
            this.groupBox2.Location = new System.Drawing.Point(17, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 89);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "C# sources";
            // 
            // chbExtractAllCSSources
            // 
            this.chbExtractAllCSSources.AutoSize = true;
            this.chbExtractAllCSSources.Location = new System.Drawing.Point(127, 25);
            this.chbExtractAllCSSources.Name = "chbExtractAllCSSources";
            this.chbExtractAllCSSources.Size = new System.Drawing.Size(151, 17);
            this.chbExtractAllCSSources.TabIndex = 4;
            this.chbExtractAllCSSources.Text = "Always Extract All Sources";
            this.chbExtractAllCSSources.UseVisualStyleBackColor = true;
            this.chbExtractAllCSSources.CheckedChanged += new System.EventHandler(this.chbExtractAllCSSources_CheckedChanged);
            // 
            // edtCSPath
            // 
            this.edtCSPath.Location = new System.Drawing.Point(51, 48);
            this.edtCSPath.Name = "edtCSPath";
            this.edtCSPath.Size = new System.Drawing.Size(540, 20);
            this.edtCSPath.TabIndex = 2;
            // 
            // lbSavingStatus
            // 
            this.lbSavingStatus.AutoSize = true;
            this.lbSavingStatus.ForeColor = System.Drawing.Color.LightGreen;
            this.lbSavingStatus.Location = new System.Drawing.Point(98, 525);
            this.lbSavingStatus.Name = "lbSavingStatus";
            this.lbSavingStatus.Size = new System.Drawing.Size(0, 13);
            this.lbSavingStatus.TabIndex = 10;
            // 
            // edtApplicatinName
            // 
            this.edtApplicatinName.Location = new System.Drawing.Point(393, 16);
            this.edtApplicatinName.Name = "edtApplicatinName";
            this.edtApplicatinName.Size = new System.Drawing.Size(255, 20);
            this.edtApplicatinName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(268, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Application Name";
            // 
            // chbSchedulerDb
            // 
            this.chbSchedulerDb.AutoSize = true;
            this.chbSchedulerDb.Location = new System.Drawing.Point(271, 45);
            this.chbSchedulerDb.Name = "chbSchedulerDb";
            this.chbSchedulerDb.Size = new System.Drawing.Size(255, 17);
            this.chbSchedulerDb.TabIndex = 13;
            this.chbSchedulerDb.Text = "Separate Db Connection for the Quartz Sheduler";
            this.chbSchedulerDb.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBrowseLogPath);
            this.groupBox3.Controls.Add(this.edtLogPath);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(17, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(631, 68);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // btnBrowseLogPath
            // 
            this.btnBrowseLogPath.Location = new System.Drawing.Point(597, 28);
            this.btnBrowseLogPath.Name = "btnBrowseLogPath";
            this.btnBrowseLogPath.Size = new System.Drawing.Size(28, 24);
            this.btnBrowseLogPath.TabIndex = 3;
            this.btnBrowseLogPath.Text = "...";
            this.btnBrowseLogPath.UseVisualStyleBackColor = true;
            this.btnBrowseLogPath.Click += new System.EventHandler(this.btnBrowseLogPath_Click);
            // 
            // edtLogPath
            // 
            this.edtLogPath.Location = new System.Drawing.Point(51, 28);
            this.edtLogPath.Name = "edtLogPath";
            this.edtLogPath.Size = new System.Drawing.Size(540, 20);
            this.edtLogPath.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Path";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBrowseSourceControlAuthPath);
            this.groupBox4.Controls.Add(this.edtSourceControlAuthPath);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnBrowseDefWorkingCopyPath);
            this.groupBox4.Controls.Add(this.edtDefWorkingCopyPath);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.chbUseSvn);
            this.groupBox4.Controls.Add(this.btnBrowseDefPackagesWorkingCopyPath);
            this.groupBox4.Controls.Add(this.edtDefPackagesWorkingCopyPath);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(17, 357);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(631, 139);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SVN Settings";
            // 
            // btnBrowseSourceControlAuthPath
            // 
            this.btnBrowseSourceControlAuthPath.Location = new System.Drawing.Point(597, 99);
            this.btnBrowseSourceControlAuthPath.Name = "btnBrowseSourceControlAuthPath";
            this.btnBrowseSourceControlAuthPath.Size = new System.Drawing.Size(28, 24);
            this.btnBrowseSourceControlAuthPath.TabIndex = 24;
            this.btnBrowseSourceControlAuthPath.Text = "...";
            this.btnBrowseSourceControlAuthPath.UseVisualStyleBackColor = true;
            this.btnBrowseSourceControlAuthPath.Click += new System.EventHandler(this.btnBrowseSourceControlAuthPath_Click);
            // 
            // edtSourceControlAuthPath
            // 
            this.edtSourceControlAuthPath.Location = new System.Drawing.Point(216, 99);
            this.edtSourceControlAuthPath.Name = "edtSourceControlAuthPath";
            this.edtSourceControlAuthPath.Size = new System.Drawing.Size(375, 20);
            this.edtSourceControlAuthPath.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Source Control Auth Path";
            // 
            // btnBrowseDefWorkingCopyPath
            // 
            this.btnBrowseDefWorkingCopyPath.Location = new System.Drawing.Point(597, 47);
            this.btnBrowseDefWorkingCopyPath.Name = "btnBrowseDefWorkingCopyPath";
            this.btnBrowseDefWorkingCopyPath.Size = new System.Drawing.Size(28, 24);
            this.btnBrowseDefWorkingCopyPath.TabIndex = 21;
            this.btnBrowseDefWorkingCopyPath.Text = "...";
            this.btnBrowseDefWorkingCopyPath.UseVisualStyleBackColor = true;
            this.btnBrowseDefWorkingCopyPath.Click += new System.EventHandler(this.btnBrowseDefWorkingCopyPath_Click);
            // 
            // edtDefWorkingCopyPath
            // 
            this.edtDefWorkingCopyPath.Location = new System.Drawing.Point(216, 47);
            this.edtDefWorkingCopyPath.Name = "edtDefWorkingCopyPath";
            this.edtDefWorkingCopyPath.Size = new System.Drawing.Size(375, 20);
            this.edtDefWorkingCopyPath.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Default Working Copy Path";
            // 
            // chbUseSvn
            // 
            this.chbUseSvn.AutoSize = true;
            this.chbUseSvn.Location = new System.Drawing.Point(10, 24);
            this.chbUseSvn.Name = "chbUseSvn";
            this.chbUseSvn.Size = new System.Drawing.Size(70, 17);
            this.chbUseSvn.TabIndex = 18;
            this.chbUseSvn.Text = "Use SVN";
            this.chbUseSvn.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDefPackagesWorkingCopyPath
            // 
            this.btnBrowseDefPackagesWorkingCopyPath.Location = new System.Drawing.Point(597, 73);
            this.btnBrowseDefPackagesWorkingCopyPath.Name = "btnBrowseDefPackagesWorkingCopyPath";
            this.btnBrowseDefPackagesWorkingCopyPath.Size = new System.Drawing.Size(28, 24);
            this.btnBrowseDefPackagesWorkingCopyPath.TabIndex = 3;
            this.btnBrowseDefPackagesWorkingCopyPath.Text = "...";
            this.btnBrowseDefPackagesWorkingCopyPath.UseVisualStyleBackColor = true;
            this.btnBrowseDefPackagesWorkingCopyPath.Click += new System.EventHandler(this.btnBrowseDefPackagesWorkingCopyPath_Click);
            // 
            // edtDefPackagesWorkingCopyPath
            // 
            this.edtDefPackagesWorkingCopyPath.Location = new System.Drawing.Point(216, 73);
            this.edtDefPackagesWorkingCopyPath.Name = "edtDefPackagesWorkingCopyPath";
            this.edtDefPackagesWorkingCopyPath.Size = new System.Drawing.Size(375, 20);
            this.edtDefPackagesWorkingCopyPath.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Default Packages Working Copy Path";
            // 
            // BpmonlineConfiguration
            // 
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lbSavingStatus);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chbSchedulerDb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtApplicatinName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtMaxEntityNameLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtWebSocketsPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtSessionTimeOut);
            this.Controls.Add(this.btnSave);
            this.Name = "BpmonlineConfiguration";
            this.Size = new System.Drawing.Size(665, 579);
            ((System.ComponentModel.ISupportInitialize)(this.edtSessionTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxEntityNameLength)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown edtSessionTimeOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtWebSocketsPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown edtMaxEntityNameLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbUncompressedJS;
        private System.Windows.Forms.Button btnBrowseJSPath;
        private System.Windows.Forms.TextBox edtJSPath;
        private System.Windows.Forms.Label lbJSPath;
        private System.Windows.Forms.CheckBox chbExtractJS;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnBrowseCSPath;
        private System.Windows.Forms.Label lbCSPath;
        private System.Windows.Forms.CheckBox chbExtractCS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbExtractAllCSSources;
        private System.Windows.Forms.TextBox edtCSPath;
        private System.Windows.Forms.Label lbSavingStatus;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox edtApplicatinName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbSchedulerDb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowseLogPath;
        private System.Windows.Forms.TextBox edtLogPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBrowseDefPackagesWorkingCopyPath;
        private System.Windows.Forms.TextBox edtDefPackagesWorkingCopyPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbUseSvn;
        private System.Windows.Forms.Button btnBrowseSourceControlAuthPath;
        private System.Windows.Forms.TextBox edtSourceControlAuthPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBrowseDefWorkingCopyPath;
        private System.Windows.Forms.TextBox edtDefWorkingCopyPath;
        private System.Windows.Forms.Label label7;
    }
}
