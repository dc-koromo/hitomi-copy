using Hitomi_Copy_2;

namespace Hitomi_Copy
{
    partial class frmArtistInfo
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
            this.components = new System.ComponentModel.Container();
            this.ImagePanel = new Hitomi_Copy_2.ScrollFixLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.모두선택AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모두선택취소CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.제목비슷한작품선택취소SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이미다운로드된작품선택취소GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.작가북마크에추가BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.자세한정보보기DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvMyTagRank = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bDownload = new System.Windows.Forms.Button();
            this.bDownloadAll = new System.Windows.Forms.Button();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.bTidy = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImagePanel
            // 
            this.ImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ImagePanel.ContextMenuStrip = this.contextMenuStrip1;
            this.ImagePanel.Location = new System.Drawing.Point(254, 15);
            this.ImagePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(1427, 642);
            this.ImagePanel.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.모두선택AToolStripMenuItem,
            this.모두선택취소CToolStripMenuItem,
            this.toolStripMenuItem1,
            this.제목비슷한작품선택취소SToolStripMenuItem,
            this.이미다운로드된작품선택취소GToolStripMenuItem,
            this.toolStripMenuItem2,
            this.작가북마크에추가BToolStripMenuItem,
            this.toolStripMenuItem3,
            this.자세한정보보기DToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(263, 154);
            // 
            // 모두선택AToolStripMenuItem
            // 
            this.모두선택AToolStripMenuItem.Name = "모두선택AToolStripMenuItem";
            this.모두선택AToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.모두선택AToolStripMenuItem.Text = "모두 선택(&A)";
            this.모두선택AToolStripMenuItem.Click += new System.EventHandler(this.모두선택AToolStripMenuItem_Click);
            // 
            // 모두선택취소CToolStripMenuItem
            // 
            this.모두선택취소CToolStripMenuItem.Name = "모두선택취소CToolStripMenuItem";
            this.모두선택취소CToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.모두선택취소CToolStripMenuItem.Text = "모두 선택 취소(&C)";
            this.모두선택취소CToolStripMenuItem.Click += new System.EventHandler(this.모두선택취소CToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(259, 6);
            // 
            // 제목비슷한작품선택취소SToolStripMenuItem
            // 
            this.제목비슷한작품선택취소SToolStripMenuItem.Name = "제목비슷한작품선택취소SToolStripMenuItem";
            this.제목비슷한작품선택취소SToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.제목비슷한작품선택취소SToolStripMenuItem.Text = "제목 비슷한 작품 선택 취소(&S)";
            this.제목비슷한작품선택취소SToolStripMenuItem.Click += new System.EventHandler(this.제목비슷한작품선택취소SToolStripMenuItem_Click);
            // 
            // 이미다운로드된작품선택취소GToolStripMenuItem
            // 
            this.이미다운로드된작품선택취소GToolStripMenuItem.Name = "이미다운로드된작품선택취소GToolStripMenuItem";
            this.이미다운로드된작품선택취소GToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.이미다운로드된작품선택취소GToolStripMenuItem.Text = "이미 다운로드된 작품 선택 취소(&G)";
            this.이미다운로드된작품선택취소GToolStripMenuItem.Click += new System.EventHandler(this.이미다운로드된작품선택취소GToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(259, 6);
            // 
            // 작가북마크에추가BToolStripMenuItem
            // 
            this.작가북마크에추가BToolStripMenuItem.Name = "작가북마크에추가BToolStripMenuItem";
            this.작가북마크에추가BToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.작가북마크에추가BToolStripMenuItem.Text = "작가 북마크에 추가(&B)";
            this.작가북마크에추가BToolStripMenuItem.Click += new System.EventHandler(this.작가북마크에추가BToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(259, 6);
            // 
            // 자세한정보보기DToolStripMenuItem
            // 
            this.자세한정보보기DToolStripMenuItem.Name = "자세한정보보기DToolStripMenuItem";
            this.자세한정보보기DToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.자세한정보보기DToolStripMenuItem.Text = "자세한 정보 보기(&D)";
            this.자세한정보보기DToolStripMenuItem.Click += new System.EventHandler(this.자세한정보보기DToolStripMenuItem_Click);
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
            this.lvMyTagRank.SelectedIndexChanged += new System.EventHandler(this.lvMyTagRank_SelectedIndexChanged);
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
            this.pbLoad.Location = new System.Drawing.Point(433, 672);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(987, 9);
            this.pbLoad.TabIndex = 17;
            // 
            // bTidy
            // 
            this.bTidy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bTidy.Location = new System.Drawing.Point(254, 664);
            this.bTidy.Name = "bTidy";
            this.bTidy.Size = new System.Drawing.Size(160, 23);
            this.bTidy.TabIndex = 19;
            this.bTidy.Text = "이름 비슷한 작품 정리";
            this.bTidy.UseVisualStyleBackColor = true;
            this.bTidy.Click += new System.EventHandler(this.bTidy_Click);
            // 
            // frmArtistInfo
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
            this.Controls.Add(this.bTidy);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1080, 451);
            this.Name = "frmArtistInfo";
            this.Text = "작가 : ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmArtistInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmArtistInfo_Load);
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Button bTidy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 모두선택AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모두선택취소CToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 제목비슷한작품선택취소SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이미다운로드된작품선택취소GToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 작가북마크에추가BToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 자세한정보보기DToolStripMenuItem;
    }
}