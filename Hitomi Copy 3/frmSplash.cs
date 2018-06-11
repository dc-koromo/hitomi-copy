﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_2
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private async void frmSplash_Load(object sender, EventArgs e)
        {
            try
            {
                if (HitomiData.Instance.CheckTagdataExist())
                {
                    await Task.Run(() => HitomiData.Instance.LoadTagdataJson());
                }
                else
                {
                    lStatus.Text = "데이터를 다운로드 중 입니다... 이 작업은 수 분 정도 걸립니다.";
                    await Task.Run(() => HitomiData.Instance.DownloadTagdata());
                }

                if (HitomiData.Instance.CheckMetadataExist())
                {
                    await Task.Run(() => HitomiData.Instance.LoadMetadataJson());
                }
                else
                {
                    lStatus.Text = "데이터를 다운로드 중 입니다... 이 작업은 수 분 정도 걸립니다.";
                    await Task.Run(() => HitomiData.Instance.DownloadMetadata());
                }

                (Application.OpenForms["frmMain"] as Hitomi_Copy_3.frmMain).OnTab();
                Application.OpenForms["frmMain"].BringToFront();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("심각한 오류가 발생하여 계속 진행할 수 없습니다. 네트워크 설정이 잘못되었거나 차단되어있을 가능성이 높습니다." +
                    "이 오류가 계속 발생한다면 koromo.software@gmail.com로 오류메시지를 보내주세요.\r\n메시지: "+ex.Message+"\r\n스택: "+ex.StackTrace, "Hitomi Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
