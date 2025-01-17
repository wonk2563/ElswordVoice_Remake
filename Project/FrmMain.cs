﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace ElswordVoice
{
    public partial class FrmMain : Form
    {
        /**
          *主表單 － 2016/02/14 IncrEdibLe (Robby)
          */

        Config.Text txt = new Config.Text();
        Config.Data data = new Config.Data();
        Config.Initial ini = new Config.Initial();
        Config.Net net = new Config.Net();
        Config.Controller con = new Config.Controller();

        public bool isAlreadyGame = false;    // 是否已經進入遊戲
        public bool isAlreadyUpdate = false;    // 是否已經檢查更新
        public bool isRecover = false;          // 是否已經還原
        public bool isReplace = false;          // 是否已經取代自訂
        public bool isStart = false;            // 是否已經開始偵測

        public int intAlert = 10;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WM_LBUTTONDBLCLK = 0x00A3;

        public FrmMain()
        {
            InitializeComponent();   
            WorkMode(true);              
        }

        /*protected override void WndProc(ref Message m)
        {

            // 畫面拖曳
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                isStart = !isStart;
                Invalidate(); // Refresh
                WorkMode(isStart);
                return;
            }

            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
                default:
                    Console.WriteLine(m.Msg);
                    break;
            }
            base.WndProc(ref m);
        }*/

        

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // AppSet
            if (ini.LoadCheck() == true)
            {
                MessageBox.Show(txt.msg_loadcheck, txt.msg_title_alert, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Dispose();
            }

            // 表單定義
            this.TransparencyKey = SystemColors.WindowFrame;
            this.Location = ini.SetLocation(this.Width, this.Height);
            this.Icon = Properties.Resources.favicon;

            

            // 工作列通知區
            noficon.Icon = Properties.Resources.favicon;
            noficon.Text = txt.nof_title;
            noficon.BalloonTipIcon = ToolTipIcon.Info;
            noficon.BalloonTipTitle = txt.nof_eve;
            noficon.BalloonTipText = txt.nof_convert;

            // 右鍵選單
            conMenu.Items[0].Text = txt.menu_ver;

            // 檢查版本
          

            Thread.Sleep(1000);
           
        }

        

        private void WorkMode(bool value)
        {
            timLoad.Enabled = value;
            if (value == true)
            {
                // Initial
                isRecover = false;
                isReplace = false;
                isAlreadyUpdate = false;                
                this.ShowInTaskbar = false;     //不出現在工具列
                this.Hide();
            }
        }

        private void timAlert_Tick(object sender, EventArgs e)
        {
            intAlert -= 1;
            picLoad.Visible = true;
            if (intAlert <= 0)
            {
                picLoad.Visible = false;
                this.Hide();
                intAlert = 10;
                timAlert.Stop();
            }
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            Process[] BFWeb = Process.GetProcessesByName(txt.exe_web);     //1.登入beanfun資料庫
            Process[] BFcore = Process.GetProcessesByName(txt.exe_core);  //2.啟動beanfun核心引擎
            Process[] elsword = Process.GetProcessesByName(txt.exe_elsword);      //3.艾爾之光更新
            Process[] elswordx = Process.GetProcessesByName(txt.exe_x2);

            if (BFWeb.Length > 0)
            {
                if (!bwkRecover.IsBusy && !isRecover)
                {
                    this.Show();
                    isRecover = true;
                    bwkRecover.RunWorkerAsync();
                }
            }
            else if (BFcore.Length > 0)
            {
                if (!bwkRecover.IsBusy && !isRecover)
                {
                    this.Show();
                    isRecover = true;
                    bwkRecover.RunWorkerAsync();
                }
            }
            else if (elsword.Length > 0)
            {
                // 是否更新完畢,這裡刻意設定true,
                // 表示更新中,但不知所花費時間
                isAlreadyUpdate = true;
            }

            // 不斷地偵測,當官方更新檔案消失=結束才繼續做
            if (elsword.Length == 0 && isAlreadyUpdate == true)
            {
                if (!bwkReplace.IsBusy && !isReplace)
                {
                    isReplace = true;
                    timAlert.Start();
                    bwkReplace.RunWorkerAsync();
                }
                isAlreadyUpdate = false;
                isReplace = false;
            }


            if (elswordx.Length > 0)
            {
                // 是否進入遊戲,這裡刻意設定true,
                // 表示遊戲中,但不知所花費時間
                isAlreadyGame = true;
            }

            // 不斷地偵測,當遊戲消失=結束才繼續檔案還原，防止更新時重新下載
            if (elswordx.Length == 0 && isAlreadyGame == true)
            {
                con.DeleteRegedit();
                con.DeleteCustomFiles(data.GetDataPath(), data.GetRemainFiles());
                con.RenameToKom(data.GetDataPath(), data.GetRemainFiles());
                isAlreadyGame = false;
            }            
        }


        private void bwkRecover_DoWork(object sender, DoWorkEventArgs e)
        {
            con.DeleteRegedit();
            con.DeleteCustomFiles(data.GetDataPath(), data.GetRemainFiles());
            con.RenameToKom(data.GetDataPath(), data.GetRemainFiles());
        }

        private void bwkReplace_DoWork(object sender, DoWorkEventArgs e)
        {
            con.RenameToTemp(data.GetDataPath(), data.GetCustomFiles());
            con.CopyCustomFiles(data.GetExChangePath(), data.GetDataPath(), data.GetCustomFiles());
        }

        private void bwkRecover_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isReplace = false;
        }

        private void bwkReplace_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isRecover = false;
            isAlreadyUpdate = false;

            noficon.ShowBalloonTip(10);
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            noficon.BalloonTipText = txt.nof_here;
            noficon.ShowBalloonTip(5);
            noficon.BalloonTipText = txt.nof_convert;
            this.Hide();
        }

        

       

        private void itemExit_Click(object sender, EventArgs e)
        {
            this.noficon.Dispose();
            this.Dispose();
            this.Close();
        }
        

        private void itemRecovery_Click(object sender, EventArgs e)
        {
            try
            {
                con.DeleteRegedit();
                con.DeleteCustomFiles(data.GetDataPath(), data.GetRemainFiles());
                con.RenameToKom(data.GetDataPath(), data.GetRemainFiles());

                MessageBox.Show("檔案還原成功。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("請先關掉遊戲，再嘗試還原。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }
    }
}
