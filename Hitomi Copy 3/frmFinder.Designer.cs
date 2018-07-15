namespace Hitomi_Copy_3
{
    partial class frmFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinder));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.bSearch = new MetroFramework.Controls.MetroButton();
            this.tbSearch = new MetroFramework.Controls.MetroTextBox();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.제목으로검색TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작가로검색AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그룹으로검색GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시리즈로검색SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.캐릭터로검색CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.태그로검색GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bDownloadAll = new System.Windows.Forms.Button();
            this.bDownload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new Hitomi_Copy_2.AutoCompleteListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(1116, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(468, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Copyright (C) 2018. DCInside Programming Gallery Union. All Rights Reserved.";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.Location = new System.Drawing.Point(1470, 31);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(114, 23);
            this.bSearch.Style = MetroFramework.MetroColorStyle.Pink;
            this.bSearch.TabIndex = 7;
            this.bSearch.Text = "검색";
            this.bSearch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bSearch.UseSelectable = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_ClickAsync);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbSearch.CustomButton.Image = null;
            this.tbSearch.CustomButton.Location = new System.Drawing.Point(1430, 1);
            this.tbSearch.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearch.CustomButton.Name = "";
            this.tbSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbSearch.CustomButton.TabIndex = 1;
            this.tbSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSearch.CustomButton.UseSelectable = true;
            this.tbSearch.CustomButton.Visible = false;
            this.tbSearch.Lines = new string[] {
        "recent:0-25"};
            this.tbSearch.Location = new System.Drawing.Point(12, 31);
            this.tbSearch.MaxLength = 32767;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PasswordChar = '\0';
            this.tbSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbSearch.SelectedText = "";
            this.tbSearch.SelectionLength = 0;
            this.tbSearch.SelectionStart = 0;
            this.tbSearch.ShortcutsEnabled = true;
            this.tbSearch.Size = new System.Drawing.Size(1452, 23);
            this.tbSearch.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbSearch.TabIndex = 6;
            this.tbSearch.Text = "recent:0-25";
            this.tbSearch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSearch.UseSelectable = true;
            this.tbSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // lvHistory
            // 
            this.lvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader29,
            this.columnHeader24,
            this.columnHeader27,
            this.columnHeader25,
            this.columnHeader28,
            this.columnHeader1,
            this.columnHeader26,
            this.columnHeader2,
            this.columnHeader3});
            this.lvHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.Location = new System.Drawing.Point(12, 60);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(1572, 574);
            this.lvHistory.TabIndex = 10;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvHistory_MouseDoubleClick);
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "아이디";
            this.columnHeader22.Width = 79;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "제목";
            this.columnHeader23.Width = 354;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "타입";
            this.columnHeader29.Width = 86;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "작가";
            this.columnHeader24.Width = 105;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "그룹";
            this.columnHeader27.Width = 151;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "시리즈";
            this.columnHeader25.Width = 144;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "캐릭터";
            this.columnHeader28.Width = 145;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "업로드 시간";
            this.columnHeader1.Width = 163;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "태그";
            this.columnHeader26.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "다운";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "히든";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 40;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.제목으로검색TToolStripMenuItem,
            this.작가로검색AToolStripMenuItem,
            this.그룹으로검색GToolStripMenuItem,
            this.시리즈로검색SToolStripMenuItem,
            this.캐릭터로검색CToolStripMenuItem,
            this.태그로검색GToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 제목으로검색TToolStripMenuItem
            // 
            this.제목으로검색TToolStripMenuItem.Name = "제목으로검색TToolStripMenuItem";
            this.제목으로검색TToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.제목으로검색TToolStripMenuItem.Text = "제목으로 검색(&T)";
            this.제목으로검색TToolStripMenuItem.Click += new System.EventHandler(this.제목으로검색TToolStripMenuItem_Click);
            // 
            // 작가로검색AToolStripMenuItem
            // 
            this.작가로검색AToolStripMenuItem.Name = "작가로검색AToolStripMenuItem";
            this.작가로검색AToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.작가로검색AToolStripMenuItem.Text = "작가로 검색(&A)";
            // 
            // 그룹으로검색GToolStripMenuItem
            // 
            this.그룹으로검색GToolStripMenuItem.Name = "그룹으로검색GToolStripMenuItem";
            this.그룹으로검색GToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.그룹으로검색GToolStripMenuItem.Text = "그룹으로 검색(&G)";
            // 
            // 시리즈로검색SToolStripMenuItem
            // 
            this.시리즈로검색SToolStripMenuItem.Name = "시리즈로검색SToolStripMenuItem";
            this.시리즈로검색SToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.시리즈로검색SToolStripMenuItem.Text = "시리즈로 검색(&S)";
            // 
            // 캐릭터로검색CToolStripMenuItem
            // 
            this.캐릭터로검색CToolStripMenuItem.Name = "캐릭터로검색CToolStripMenuItem";
            this.캐릭터로검색CToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.캐릭터로검색CToolStripMenuItem.Text = "캐릭터로 검색(&C)";
            // 
            // 태그로검색GToolStripMenuItem
            // 
            this.태그로검색GToolStripMenuItem.Name = "태그로검색GToolStripMenuItem";
            this.태그로검색GToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.태그로검색GToolStripMenuItem.Text = "태그로 검색(&G)";
            // 
            // bDownloadAll
            // 
            this.bDownloadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDownloadAll.Location = new System.Drawing.Point(1443, 640);
            this.bDownloadAll.Name = "bDownloadAll";
            this.bDownloadAll.Size = new System.Drawing.Size(141, 23);
            this.bDownloadAll.TabIndex = 31;
            this.bDownloadAll.Text = "모두 다운로드";
            this.bDownloadAll.UseVisualStyleBackColor = true;
            this.bDownloadAll.Click += new System.EventHandler(this.bDownloadAll_Click);
            // 
            // bDownload
            // 
            this.bDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDownload.Location = new System.Drawing.Point(1349, 640);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(88, 23);
            this.bDownload.TabIndex = 30;
            this.bDownload.Text = "다운로드";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.bDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(757, 644);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "대기중";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(558, 275);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(367, 124);
            this.listBox1.TabIndex = 29;
            this.listBox1.Visible = false;
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // frmFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1595, 671);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bDownloadAll);
            this.Controls.Add(this.bDownload);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.metroLabel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finder";
            this.Load += new System.EventHandler(this.frmFinder_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton bSearch;
        private MetroFramework.Controls.MetroTextBox tbSearch;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private Hitomi_Copy_2.AutoCompleteListBox listBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button bDownloadAll;
        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 제목으로검색TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작가로검색AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 그룹으로검색GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 시리즈로검색SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 캐릭터로검색CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 태그로검색GToolStripMenuItem;
    }
}