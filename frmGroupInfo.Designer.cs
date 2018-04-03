﻿namespace Hitomi_Copy
{
    partial class frmGroupInfo
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
            this.ImagePanel = new Hitomi_Copy.ScrollFixLayoutPanel();
            this.lvMyTagRank = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bDownload = new System.Windows.Forms.Button();
            this.bDownloadAll = new System.Windows.Forms.Button();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ImagePanel
            // 
            this.ImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ImagePanel.Location = new System.Drawing.Point(254, 15);
            this.ImagePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(1427, 642);
            this.ImagePanel.TabIndex = 5;
            // 
            // lvMyTagRank
            // 
            this.lvMyTagRank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvMyTagRank.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvMyTagRank.FullRowSelect = true;
            this.lvMyTagRank.GridLines = true;
            this.lvMyTagRank.Location = new System.Drawing.Point(12, 15);
            this.lvMyTagRank.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvMyTagRank.Name = "lvMyTagRank";
            this.lvMyTagRank.Size = new System.Drawing.Size(236, 671);
            this.lvMyTagRank.TabIndex = 6;
            this.lvMyTagRank.UseCompatibleStateImageBehavior = false;
            this.lvMyTagRank.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "항목";
            this.columnHeader1.Width = 133;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "카운트";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 69;
            // 
            // bDownload
            // 
            this.bDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDownload.Location = new System.Drawing.Point(1446, 664);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(88, 23);
            this.bDownload.TabIndex = 7;
            this.bDownload.Text = "다운로드";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.bDownload_Click);
            // 
            // bDownloadAll
            // 
            this.bDownloadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDownloadAll.Location = new System.Drawing.Point(1540, 664);
            this.bDownloadAll.Name = "bDownloadAll";
            this.bDownloadAll.Size = new System.Drawing.Size(141, 23);
            this.bDownloadAll.TabIndex = 16;
            this.bDownloadAll.Text = "모두 다운로드";
            this.bDownloadAll.UseVisualStyleBackColor = true;
            this.bDownloadAll.Click += new System.EventHandler(this.bDownloadAll_Click);
            // 
            // pbLoad
            // 
            this.pbLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoad.Location = new System.Drawing.Point(289, 672);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(1131, 9);
            this.pbLoad.TabIndex = 17;
            // 
            // frmGroupInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1693, 699);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.bDownloadAll);
            this.Controls.Add(this.bDownload);
            this.Controls.Add(this.lvMyTagRank);
            this.Controls.Add(this.ImagePanel);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1080, 451);
            this.Name = "frmGroupInfo";
            this.Text = "그룹 : ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmArtistInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmArtistInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScrollFixLayoutPanel ImagePanel;
        private System.Windows.Forms.ListView lvMyTagRank;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.Button bDownloadAll;
        private System.Windows.Forms.ProgressBar pbLoad;
    }
}