
namespace HyenaFTP
{
    partial class HyenaFTP
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
            this.selectPath = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.AllbackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFileStatus = new System.Windows.Forms.Label();
            this.btnFileUpload = new System.Windows.Forms.Button();
            this.txtSeletFile = new System.Windows.Forms.TextBox();
            this.progressBarFile = new System.Windows.Forms.ProgressBar();
            this.btnSeletFile = new System.Windows.Forms.Button();
            this.tabUpload = new System.Windows.Forms.TabControl();
            this.tabFolder = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilesinPro = new System.Windows.Forms.Label();
            this.AllprogressBar = new System.Windows.Forms.ProgressBar();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabUpload.SuspendLayout();
            this.tabFolder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectPath
            // 
            this.selectPath.BackColor = System.Drawing.Color.Blue;
            this.selectPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.selectPath.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.selectPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.selectPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.selectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectPath.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectPath.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.selectPath.Location = new System.Drawing.Point(34, 35);
            this.selectPath.Name = "selectPath";
            this.selectPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectPath.Size = new System.Drawing.Size(106, 29);
            this.selectPath.TabIndex = 4;
            this.selectPath.Text = "폴더 선택";
            this.selectPath.UseVisualStyleBackColor = false;
            this.selectPath.Click += new System.EventHandler(this.selectPath_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.progressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar.Location = new System.Drawing.Point(146, 114);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(482, 14);
            this.progressBar.TabIndex = 5;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(585, 26);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPath.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtPath.Location = new System.Drawing.Point(146, 36);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(482, 25);
            this.txtPath.TabIndex = 9;
            // 
            // AllbackgroundWorker
            // 
            this.AllbackgroundWorker.WorkerReportsProgress = true;
            this.AllbackgroundWorker.WorkerSupportsCancellation = true;
            this.AllbackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AllbackgroundWorker_ProgressChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(146, 130);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(585, 26);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblFileStatus);
            this.panel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(146, 134);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(585, 25);
            this.panel3.TabIndex = 23;
            // 
            // lblFileStatus
            // 
            this.lblFileStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileStatus.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblFileStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFileStatus.Location = new System.Drawing.Point(0, 0);
            this.lblFileStatus.Name = "lblFileStatus";
            this.lblFileStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFileStatus.Size = new System.Drawing.Size(585, 25);
            this.lblFileStatus.TabIndex = 7;
            this.lblFileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFileUpload
            // 
            this.btnFileUpload.BackColor = System.Drawing.Color.Maroon;
            this.btnFileUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFileUpload.Enabled = false;
            this.btnFileUpload.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnFileUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnFileUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFileUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileUpload.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFileUpload.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnFileUpload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFileUpload.Location = new System.Drawing.Point(34, 95);
            this.btnFileUpload.Name = "btnFileUpload";
            this.btnFileUpload.Size = new System.Drawing.Size(106, 33);
            this.btnFileUpload.TabIndex = 20;
            this.btnFileUpload.Text = "파일 업로드";
            this.btnFileUpload.UseVisualStyleBackColor = false;
            this.btnFileUpload.Click += new System.EventHandler(this.btnFileUpload_Click);
            // 
            // txtSeletFile
            // 
            this.txtSeletFile.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSeletFile.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSeletFile.Location = new System.Drawing.Point(146, 36);
            this.txtSeletFile.Name = "txtSeletFile";
            this.txtSeletFile.ReadOnly = true;
            this.txtSeletFile.Size = new System.Drawing.Size(482, 25);
            this.txtSeletFile.TabIndex = 19;
            // 
            // progressBarFile
            // 
            this.progressBarFile.ForeColor = System.Drawing.Color.Red;
            this.progressBarFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBarFile.Location = new System.Drawing.Point(146, 95);
            this.progressBarFile.Name = "progressBarFile";
            this.progressBarFile.Size = new System.Drawing.Size(482, 33);
            this.progressBarFile.TabIndex = 18;
            // 
            // btnSeletFile
            // 
            this.btnSeletFile.BackColor = System.Drawing.Color.Blue;
            this.btnSeletFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSeletFile.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSeletFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnSeletFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSeletFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeletFile.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSeletFile.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSeletFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSeletFile.Location = new System.Drawing.Point(34, 35);
            this.btnSeletFile.Name = "btnSeletFile";
            this.btnSeletFile.Size = new System.Drawing.Size(106, 29);
            this.btnSeletFile.TabIndex = 17;
            this.btnSeletFile.Text = "파일 선택";
            this.btnSeletFile.UseVisualStyleBackColor = false;
            this.btnSeletFile.Click += new System.EventHandler(this.btnSeletFile_Click);
            // 
            // tabUpload
            // 
            this.tabUpload.Controls.Add(this.tabFolder);
            this.tabUpload.Controls.Add(this.tabFile);
            this.tabUpload.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabUpload.Location = new System.Drawing.Point(51, 40);
            this.tabUpload.Name = "tabUpload";
            this.tabUpload.SelectedIndex = 0;
            this.tabUpload.ShowToolTips = true;
            this.tabUpload.Size = new System.Drawing.Size(672, 216);
            this.tabUpload.TabIndex = 24;
            // 
            // tabFolder
            // 
            this.tabFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabFolder.Controls.Add(this.panel2);
            this.tabFolder.Controls.Add(this.selectPath);
            this.tabFolder.Controls.Add(this.panel1);
            this.tabFolder.Controls.Add(this.progressBar);
            this.tabFolder.Controls.Add(this.AllprogressBar);
            this.tabFolder.Controls.Add(this.txtPath);
            this.tabFolder.Controls.Add(this.btnUpload);
            this.tabFolder.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.tabFolder.Location = new System.Drawing.Point(4, 26);
            this.tabFolder.Name = "tabFolder";
            this.tabFolder.Padding = new System.Windows.Forms.Padding(3);
            this.tabFolder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabFolder.Size = new System.Drawing.Size(664, 186);
            this.tabFolder.TabIndex = 0;
            this.tabFolder.Text = "폴더 업로드";
            this.tabFolder.ToolTipText = "폴더 업로드 대상 선택...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FilesinPro);
            this.panel1.Location = new System.Drawing.Point(146, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 23);
            this.panel1.TabIndex = 15;
            // 
            // FilesinPro
            // 
            this.FilesinPro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesinPro.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilesinPro.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FilesinPro.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.FilesinPro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FilesinPro.Location = new System.Drawing.Point(0, 0);
            this.FilesinPro.Name = "FilesinPro";
            this.FilesinPro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FilesinPro.Size = new System.Drawing.Size(585, 23);
            this.FilesinPro.TabIndex = 13;
            this.FilesinPro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AllprogressBar
            // 
            this.AllprogressBar.AccessibleDescription = "dkfls";
            this.AllprogressBar.AccessibleName = "df";
            this.AllprogressBar.BackColor = System.Drawing.Color.Gray;
            this.AllprogressBar.ForeColor = System.Drawing.Color.Red;
            this.AllprogressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AllprogressBar.Location = new System.Drawing.Point(146, 95);
            this.AllprogressBar.Name = "AllprogressBar";
            this.AllprogressBar.Size = new System.Drawing.Size(482, 15);
            this.AllprogressBar.TabIndex = 12;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpload.Enabled = false;
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpload.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnUpload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpload.Location = new System.Drawing.Point(34, 95);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(106, 33);
            this.btnUpload.TabIndex = 11;
            this.btnUpload.Text = "폴더 업로드";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tabFile
            // 
            this.tabFile.BackColor = System.Drawing.Color.LightGray;
            this.tabFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabFile.Controls.Add(this.panel3);
            this.tabFile.Controls.Add(this.btnSeletFile);
            this.tabFile.Controls.Add(this.progressBarFile);
            this.tabFile.Controls.Add(this.txtSeletFile);
            this.tabFile.Controls.Add(this.btnFileUpload);
            this.tabFile.Location = new System.Drawing.Point(4, 26);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(664, 186);
            this.tabFile.TabIndex = 1;
            this.tabFile.Text = "파일 업로드";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.SystemColors.Info;
            this.btnExit.Location = new System.Drawing.Point(641, 35);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 30);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // HyenaFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(770, 299);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabUpload);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HyenaFTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hyena 파일등록 프로그램 v1.0.2";
            this.Load += new System.EventHandler(this.HyenaFTP_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabUpload.ResumeLayout(false);
            this.tabFolder.ResumeLayout(false);
            this.tabFolder.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button selectPath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtPath;
        private System.ComponentModel.BackgroundWorker AllbackgroundWorker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblFileStatus;
        private System.Windows.Forms.Button btnFileUpload;
        private System.Windows.Forms.TextBox txtSeletFile;
        private System.Windows.Forms.ProgressBar progressBarFile;
        private System.Windows.Forms.Button btnSeletFile;
        private System.Windows.Forms.TabControl tabUpload;
        private System.Windows.Forms.TabPage tabFolder;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label FilesinPro;
        private System.Windows.Forms.ProgressBar AllprogressBar;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnExit;
    }
}