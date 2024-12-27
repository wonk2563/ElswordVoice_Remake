namespace ElswordVoice
{
    partial class FrmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timLoad = new System.Windows.Forms.Timer(this.components);
            this.bwkRecover = new System.ComponentModel.BackgroundWorker();
            this.bwkReplace = new System.ComponentModel.BackgroundWorker();
            this.noficon = new System.Windows.Forms.NotifyIcon(this.components);
            this.conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRecovery = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.sep4 = new System.Windows.Forms.ToolStripSeparator();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.picLoad = new System.Windows.Forms.PictureBox();
            this.timAlert = new System.Windows.Forms.Timer(this.components);
            this.conMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // timLoad
            // 
            this.timLoad.Interval = 300;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // bwkRecover
            // 
            this.bwkRecover.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkRecover_DoWork);
            this.bwkRecover.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkRecover_RunWorkerCompleted);
            // 
            // bwkReplace
            // 
            this.bwkReplace.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkReplace_DoWork);
            this.bwkReplace.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkReplace_RunWorkerCompleted);
            // 
            // noficon
            // 
            this.noficon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.noficon.ContextMenuStrip = this.conMenu;
            this.noficon.Text = "123";
            this.noficon.Visible = true;
            // 
            // conMenu
            // 
            this.conMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemVersion,
            this.sep2,
            this.itemRecovery,
            this.itemAbout,
            this.sep4,
            this.itemExit});
            this.conMenu.Name = "contextMenuStrip1";
            this.conMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.conMenu.Size = new System.Drawing.Size(211, 140);
            // 
            // itemVersion
            // 
            this.itemVersion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.itemVersion.Enabled = false;
            this.itemVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.itemVersion.Name = "itemVersion";
            this.itemVersion.Size = new System.Drawing.Size(210, 24);
            this.itemVersion.ToolTipText = "版本君：我不能按ㄛ~";
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(207, 6);
            // 
            // itemRecovery
            // 
            this.itemRecovery.Name = "itemRecovery";
            this.itemRecovery.Size = new System.Drawing.Size(210, 24);
            this.itemRecovery.Text = "手動還原";
            this.itemRecovery.ToolTipText = "如果要恢復原檔案，請點擊此。";
            this.itemRecovery.Click += new System.EventHandler(this.itemRecovery_Click);
            // 
            // itemAbout
            // 
            this.itemAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.itemAbout.Name = "itemAbout";
            this.itemAbout.Size = new System.Drawing.Size(210, 24);
            this.itemAbout.Text = "關於";
            this.itemAbout.ToolTipText = "看看現在你用der是蛇馬版本?";
            this.itemAbout.Click += new System.EventHandler(this.itemAbout_Click);
            // 
            // sep4
            // 
            this.sep4.Name = "sep4";
            this.sep4.Size = new System.Drawing.Size(207, 6);
            // 
            // itemExit
            // 
            this.itemExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(210, 24);
            this.itemExit.Text = "結束";
            this.itemExit.ToolTipText = "不要拋7ˋ我 QAQ";
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
            // 
            // itemOpen
            // 
            this.itemOpen.Name = "itemOpen";
            this.itemOpen.Size = new System.Drawing.Size(32, 19);
            // 
            // itemInfo
            // 
            this.itemInfo.Name = "itemInfo";
            this.itemInfo.Size = new System.Drawing.Size(32, 19);
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(150, 6);
            // 
            // picLoad
            // 
            this.picLoad.BackColor = System.Drawing.Color.Transparent;
            this.picLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLoad.Cursor = System.Windows.Forms.Cursors.Default;
            this.picLoad.Image = global::ElswordVoice.Properties.Resources.loading2;
            this.picLoad.Location = new System.Drawing.Point(16, 249);
            this.picLoad.Margin = new System.Windows.Forms.Padding(4);
            this.picLoad.Name = "picLoad";
            this.picLoad.Size = new System.Drawing.Size(341, 188);
            this.picLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoad.TabIndex = 4;
            this.picLoad.TabStop = false;
            this.picLoad.Visible = false;
            // 
            // timAlert
            // 
            this.timAlert.Interval = 1000;
            this.timAlert.Tick += new System.EventHandler(this.timAlert_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(467, 619);
            this.Controls.Add(this.picLoad);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ElswordVoice";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.conMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timLoad;
        private System.ComponentModel.BackgroundWorker bwkRecover;
        private System.ComponentModel.BackgroundWorker bwkReplace;
        private System.Windows.Forms.NotifyIcon noficon;
        private System.Windows.Forms.ContextMenuStrip conMenu;
        private System.Windows.Forms.ToolStripMenuItem itemVersion;
        private System.Windows.Forms.ToolStripMenuItem itemOpen;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripMenuItem itemAbout;
        private System.Windows.Forms.ToolStripSeparator sep4;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.PictureBox picLoad;
        private System.Windows.Forms.Timer timAlert;
        private System.Windows.Forms.ToolStripMenuItem itemRecovery;
        private System.Windows.Forms.ToolStripSeparator sep3;
        private System.Windows.Forms.ToolStripMenuItem itemInfo;
    }
}

